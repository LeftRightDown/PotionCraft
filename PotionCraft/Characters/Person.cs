using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Person
    {
        public string Name { get; set; }
        public float Currency { get; set; }

        List<IItem> Inventory { get; set; }
    }
}