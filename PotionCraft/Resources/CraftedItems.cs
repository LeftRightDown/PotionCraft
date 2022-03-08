using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PotionCraft
{
    public class CraftedItems : Item
    {
        

        //Items w/Dictionary Collection
        public Dictionary<string, List<Item>> Recipes = new Dictionary<string, List<Item>>();

        //Extracting Items from External data
        public static string SetUpItems()
        {
            string output = "";
            List<Item> Newlist = LoadData.LoadLinesFromFile("../../../data/Crafteditems.txt");

            foreach (Item item in Newlist)
            {
                output = $"{item.Name}: {item.Description} {Environment.NewLine}{item.FormulaName}: {item.FormulaQuantity} ";
            }
            //for (int i = 0; i < TempItem.Length; i += 2)
            //{
            //    Recipes.Add(TempItem[i],);

            //}

            //    foreach (KeyValuePair<string, List<Item>> x in Recipes)
            //    {
            //        WriteLine($"{x.Key}: {x.Value}");
            //    }
            //}

            return output;
        }
    }
}

