using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    public class Item
    {
        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;


        public float Quantity { get; set; }
        public  string FormulaName { get; set; } = String.Empty;

        public float FormulaQuantity { get; set; } = 0

        public float Price { get; set; }


        enum Measurement { Cup = 1, Tsp = 48, Tbs = 16 }

   
        
    }
}
