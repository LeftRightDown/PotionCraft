using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    interface ICraft
    {
        Item Craft(Item craftitem, List<Item> recipe )
        {
            if (CraftedItems.DataBaseItems.TryGetValue(craftitem, out var items))
            {

            }
            
            return craftitem;     
        }

       
    }
}
