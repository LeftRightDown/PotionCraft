using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    public class CraftedItems: Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public Recipe Formula { get; set; }

        //Creating Items w/ Recipies 
        public Dictionary<string, List<Item>> Recipes;
        
        private void SetUpItems()
        {
            List<Item>  = LoadData.LoadLinesFromFile("../../data/Crafteditems");
            for (int i = 0; i < contents.Length; i += 2)
            {
                Terms.Add(contents[i], contents[i + 1]);

            }
            foreach (KeyValuePair<string, string> x in Items.Recipes)
            {
                WriteLine($"{x.Key}: {x.Value}");
            }
        }



    }
}
