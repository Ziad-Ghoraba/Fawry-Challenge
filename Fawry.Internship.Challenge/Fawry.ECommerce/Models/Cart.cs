using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry.ECommerce.Models
{
    internal class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public IReadOnlyList<CartItem> Items => items;

        public void AddProduct(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            if (product.Quantity < quantity)
                throw new InvalidOperationException("Not enough quantity in stock.");

            if (product.IsExpired())
                throw new InvalidOperationException("Product is expired.");

            var existingItem = items.FirstOrDefault(i => i.Product == product);

            int currentQuantityInCart = 0;
            if (existingItem != null)
            {
                currentQuantityInCart = existingItem.Quantity;
            }

            if (currentQuantityInCart + quantity > product.Quantity)
            {
                Console.WriteLine($"Error: Cannot add {quantity}x {product.Name}. Only {product.Quantity - currentQuantityInCart} left in stock.");
                return;
            }

            if (existingItem != null)
                existingItem.Quantity += quantity;
            else
                items.Add(new CartItem { Product = product, Quantity = quantity });
        }

        public void ReduceProductStock()
        {
            foreach (var item in items)
            {
                item.Product.Quantity -= item.Quantity;
            }
        }

        public void Clear()
        {
            items.Clear();
        }


        public bool IsEmpty() => !items.Any();

        public decimal GetSubtotal()
        {
            return items.Sum(i => i.GetTotalPrice());
        }

        public List<CartItem> GetShippableItems()
        {
            return items.Where(i => i.Product is IShippable).ToList();
        }


        public override string ToString()
        {
            string result = "";

            foreach (var item in items)
            {
                result += item.ToString() + "\n";
            }

            return result;
        }
    }
}
