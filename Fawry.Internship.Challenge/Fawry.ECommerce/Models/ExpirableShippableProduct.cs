using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry.ECommerce.Models
{
    internal class ExpirableShippableProduct : ExpirableProduct, IShippable
    {
        public double Weight { get; set; }

        public string GetName() => Name;
        public double GetWeight() => Weight;

        public override string ToString()
        {
            string weightDisplay;
            if (Weight >= 1)
                weightDisplay = $"{Weight}kg";
            else
                weightDisplay = $"{Weight * 1000}g";

            return base.ToString() + $" - Weight: {weightDisplay}";
        }
    }
}
