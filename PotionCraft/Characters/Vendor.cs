using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Vendor : Person
    {
       public static List<Item> VendorInventory = new List<Item>();
        public Vendor(string name, float currency)
        {
            Name = name;
            Currency = currency;
            
        }


        



    
    }

}