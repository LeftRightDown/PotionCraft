﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PotionCraft.Utility;

namespace PotionCraft
{
    public class Player : Person, ICraft
    {
        public List<Item> PlayerInventory = new List<Item>();
        public List<Item> StoreCraftedItems = new List<Item>();
        public Player(string name, float currency)
        {
            Name = name;
            Currency = currency;

        }

        //Get player input for search method for all keys in database return value of the key
        //write method that compares items names that were in the list that was returned from the other method
        //method compares that items with player inventory if/else statment if true.

        //search database items for a key that matches name

  
        public Item Craft(string itemname)
        {
            string output = "";
            Item Results = SearchInventory(itemname, PlayerInventory);
            return Results;
        }

        public void test()
        {
            foreach (KeyValuePair<Item, List<Item>> x in CraftedItems.DataBaseItems)
            {
                StoreCraftedItems.Add(x.Key);
            }
        }
    }
}
