using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public Recipe Formula { get; set { Name = String.Empty}
        public float Price { get; set; }

        
       enum Measurement {Cup = 1, Tsp = 48,Tbs =16 }

        

    }
}
