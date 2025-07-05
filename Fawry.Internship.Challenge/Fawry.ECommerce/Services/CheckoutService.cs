using Fawry.ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry.ECommerce.Services
{
    internal class CheckoutService
    {
        private const decimal ShippingFeePerKg = 10m;
        private readonly ShippingService shippingService;
        public CheckoutService()
        {
            shippingService = new ShippingService();
        }

        public void Checkout(Customer customer)
        {
            Cart cart = customer.Cart;

            if (cart.IsEmpty())
            {
                Console.WriteLine("Error: Cart is empty.");
                return;
            }

            decimal subtotal = cart.GetSubtotal();

            decimal totalShippingWeight = 0;
            List<CartItem> itemsToShip = new List<CartItem>();

            foreach (var item in cart.Items)
            {
                if (item.Product is ExpirableProduct exp && exp.IsExpired())
                {
                    Console.WriteLine($"Error: {item.Product.Name} is expired.");
                    return;
                }

                if (item.Product is IShippable shippable)
                {
                    totalShippingWeight += (decimal)(shippable.GetWeight() * item.Quantity);
                    itemsToShip.Add(item);
                }
            }

            decimal shippingFees = totalShippingWeight * ShippingFeePerKg;
            decimal totalAmount = subtotal + shippingFees;

            if (!customer.CanAfford(totalAmount))
            {
                Console.WriteLine("Error: Customer balance is insufficient.");
                return;
            }

            customer.Deduct(totalAmount);

            cart.ReduceProductStock();


            if (itemsToShip.Any())
            {
                shippingService.ShipItems(itemsToShip);
                Console.WriteLine();
            }

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
            {
                string name = item.Product.Name.PadRight(19);
                Console.WriteLine($"{item.Quantity}x {name} {item.GetTotalPrice()}");
            }

            cart.Clear();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Subtotal:          {subtotal}");
            Console.WriteLine($"Shipping:          {shippingFees}");
            Console.WriteLine($"Paid Amount:       {totalAmount}");
            Console.WriteLine($"Remaining Balance: {customer.Balance}");
        }
    }
}
