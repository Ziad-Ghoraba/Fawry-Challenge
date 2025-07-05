using Fawry.ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry.ECommerce.Services
{
    internal class ShippingService
    {
        public void ShipItems(List<CartItem> items)
        {
            if (items == null || !items.Any())
            {
                Console.WriteLine("No items to ship.");
                return;
            }

            Console.WriteLine("** Shipment notice **");

            double totalWeight = 0;

            foreach (var item in items)
            {
                var shippable = (IShippable)item.Product;
                double weight = shippable.GetWeight() * item.Quantity;
                string name = shippable.GetName().PadRight(21);

                if (weight >= 1)
                    Console.WriteLine($"{name} {weight} kg");
                else
                    Console.WriteLine($"{name} {weight * 1000} g");


                totalWeight += weight;
            }

            if (totalWeight >= 1)
                Console.WriteLine($"Total package weight: {totalWeight} kg");
            else
                Console.WriteLine($"Total package weight: {totalWeight * 1000} g");
        }
    }
}
