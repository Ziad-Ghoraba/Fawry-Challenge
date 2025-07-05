using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry.ECommerce.Models
{
    internal class ExpirableProduct : Product
    {
        public DateTime ExpiryDate { get; set; }

        public override bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }

        public override string ToString()
        {
            return base.ToString() + $" - Expires: {ExpiryDate.ToShortDateString()}";
        }
    }
}
