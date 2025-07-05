using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry.ECommerce.Models
{
    internal class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual bool IsExpired() => false;

        //To help in debugging and print product details directly
        public override string ToString() 
        {
            return $"Name : {Name} - Price : {Price} - Quantity : {Quantity}"; 
        }

    }
}
