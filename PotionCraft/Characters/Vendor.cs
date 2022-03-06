using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Vendor : Person
    {
        List<Item> VendorInventory;
        public Vendor()
        {
            Name = "Baba The Merchant";
            Currency = 10000f;
            VendorInventory = new List<Item>();
        }
    }

}