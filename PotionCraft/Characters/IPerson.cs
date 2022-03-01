using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    interface IPerson
    {
        string Name { get; set; }
        float Currency = 0;

        List<IItem> Inventory { get; set; }


        void InventoryAdd(IItem item);


        void InventoryRemove(IItem item)

        void BuyAndSell(IItem item, IItem requiredItem);

        bool SearchInventory(IItem word);
       
    }
}
