using Fawry.ECommerce.Models;
using Fawry.ECommerce.Services;

namespace Fawry.ECommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Create Products

            Product cheese = new ExpirableShippableProduct
            {
                Name = "Cheese",
                Price = 100m,
                Quantity = 10,
                Weight = 0.4,
                ExpiryDate = DateTime.Today.AddDays(5)
            };

            Product tv = new ShippableProduct
            {
                Name = "TV",
                Price = 5000m,
                Quantity = 5,
                Weight = 7.5
            };


            Product biscuits = new ExpirableShippableProduct
            {
                Name = "Biscuits",
                Price = 150m,
                Quantity = 4,
                Weight = 0.7,
                ExpiryDate = DateTime.Today.AddDays(1)
            };

            Product scratchCard = new Product
            {
                Name = "Mobile Scratch Card",
                Price = 50m,
                Quantity = 100
            };

            Product laptop = new ShippableProduct
            {
                Name = "Laptop",
                Price = 20000m,
                Quantity = 3,
                Weight = 2.3
            };

            Product oldMilk = new ExpirableShippableProduct
            {
                Name = "Old Milk",
                Price = 80m,
                Quantity = 5,
                Weight = 1,
                ExpiryDate = DateTime.Today.AddDays(-1)
            };

            Product meat = new ExpirableShippableProduct
            {
                Name = "Fresh Meat",
                Price = 300m,
                Quantity = 6,
                Weight = 1.2,
                ExpiryDate = DateTime.Today.AddDays(3)
            };

            #endregion


            CheckoutService checkoutService = new CheckoutService();



            Customer Ziad = new Customer
            {
                Name = "Ziad",
                Balance = 10000m
            };

            Ziad.Cart.AddProduct(cheese, 2);
            Ziad.Cart.AddProduct(tv, 1);
            Ziad.Cart.AddProduct(biscuits, 1);
            Ziad.Cart.AddProduct(scratchCard, 3);
            //Ziad.Cart.AddProduct(oldMilk, 3); //Exception

            checkoutService.Checkout(Ziad);


        }
    }
}
