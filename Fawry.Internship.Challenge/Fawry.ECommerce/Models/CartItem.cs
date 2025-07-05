using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry.ECommerce.Models
{
    internal class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }

        public override string ToString()
        {
            return $"{Quantity}x {Product.Name} \t {GetTotalPrice()}";
        }
    }
}
