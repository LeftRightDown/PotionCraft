using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    public class Player: IPerson, ICraft
    {
         List<IItem> IPerson.Inventory { get; set; }

        public string Name { get; set; }
        public float Currency { get; set; }

        public Player()
        {


        }

        void IPerson.InventoryAdd(IItem item)
        {
            ((IPerson)this).Inventory.Add(item);
        }


        void IPerson.InventoryRemove(IItem item)
        {
            ((IPerson)this).Inventory.Remove(item);
        }


        void IPerson.BuyAndSell(IItem item, IItem requiredItem)
        {
            try
            {
                if (Currency >= requiredItem.Price )
                {
                    ((IPerson)this).Inventory.Add(requiredItem);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        bool IPerson.SearchInventory(IItem word)
        {
            List<IItem> inventory = IPerson.Inventory;
            foreach (var i in inventory)
            {
                if (i.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }

        void ICraft.Craft(Recipe recipe)
        {


        }

    }
}
