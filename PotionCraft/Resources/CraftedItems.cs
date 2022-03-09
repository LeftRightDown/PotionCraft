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
        public static Dictionary<Item, List<Item>> Recipes = new Dictionary<Item, List<Item>>();
        public static List<Item> items1 = new List<Item>(); 


        //Extracting Items from External data
        public static string SetUpItems()
        {
            string output = "";
            Item[] items = LoadData.LoadLinesFromFile("../../../data/Crafteditems.txt");

            for (int i = 0; i < items.Length ; i++)
            {
                
                Recipes.Add(items[i], new List<Item>());
                items1.Add(items[i+2]);
                
            }
      

            //    foreach (KeyValuePair<string, List<Item>> x in Recipes)
            //    {
            //        WriteLine($"{x.Key}: {x.Value}");
            //    }
            //}

            return output;
        }
    }
}

