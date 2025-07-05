using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry.ECommerce.Models
{
    internal class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public bool CanAfford(decimal amount)
        {
            return Balance >= amount;
        }

        public void Deduct(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient balance.");

            Balance -= amount;
        }

        public override string ToString()
        {
            return $"{Name} - Balance: {Balance} EGP \n";
        }

        public Cart Cart { get; set; } = new Cart();

    }
}
