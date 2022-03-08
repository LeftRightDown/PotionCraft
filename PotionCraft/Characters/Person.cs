using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Person
    {

        public string Name { get; set; } = string.Empty;
        public float Currency { get; set; }

        List<Item> Inventory { get; set; } = default!;
        void InventoryAdd(Item item)
        {
            Inventory.Add(item);
        }


        void InventoryRemove(Item item)
        {
            if (Inventory.Contains(item));
        }

        void BuyAndSell(Item item, Item requiredItem)
        {

        }

        //bool SearchInventory(Item word)
        //{
          
        //    return;
        //}

    }
}