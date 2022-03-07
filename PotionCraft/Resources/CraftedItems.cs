using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PotionCraft
{
    public class CraftedItems: Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public Recipe Formula { get; set; }

        //Creating Items w/ Recipies 
        public Dictionary<string, List<Item>> Recipes = new Dictionary<string, List<Item>>();
        
        private void SetUpItems()
        {
            string[] TempItem = LoadData.LoadLinesFromFile("../../data/Crafteditems");
            for (int i = 0; i < TempItem.Length; i += 2)
            {
                Recipes.Add(TempItem[i], TempItem[i+1]);

            }
            foreach (KeyValuePair<string, string> x in Recipes)
            {
                WriteLine($"{x.Key}: {x.Value}");
            }
        }



    }
}
