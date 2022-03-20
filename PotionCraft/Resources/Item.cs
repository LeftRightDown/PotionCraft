using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    public class Item
    {
        public string Type = "";
        public string Name = "";
        public string Description = "";
        public float Quantity;
        public float Price;
        public Measurement QuantityType;
        public enum Measurement 
        { 
            Cup = 1, 
            Tsp = 48, 
            Tbs = 16 
        }

   

      
        
    }
}
