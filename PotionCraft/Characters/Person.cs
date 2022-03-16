using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Person
    {

        public string Name { get; set; } = string.Empty;
        public static float Currency { get; set; }

        public static void CurrencyAdd (float item)
        {
            Currency += item;
        }

        public static void CurrencyRemove(float item)
        {
            Currency -= item;
        }



        public static void Buy(string itemName, List<Item> list)
        {
           
            Item Results = Utility.SearchInventory(itemName, list);
              list.Add(Results);
              
        }

        public static void Sell(string itemName, List<Item> list)
        {
            Item ResultsTwo = Utility.SearchInventory(itemName, list);
            list.Remove(ResultsTwo);
            
        }

        //bool SearchInventory(Item word)
        //{

        //    return;
        //}

    }
}