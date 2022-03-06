using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Material: Item
    {
        public string Name { get; set ; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public Recipe Formula { get; set; }
        public float Price { get; set; }


        List<Item> Ingredients => LoadData.LoadLinesFromFile("../../");
    }
}