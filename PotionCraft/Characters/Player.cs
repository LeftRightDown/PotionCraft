using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PotionCraft.Utility;

namespace PotionCraft
{
    public class Player: Person, ICraft
    {
        public static List<Item> PlayerInventory;
        public Player(string name, float currency)
        {
            Name = name;
            Currency = currency;
            PlayerInventory = new List<Item>();
            PlayerInventory.Add(new Item(){Name = "Water"});
            
        }

        
        

        public string Craft(string itemname)
        {
            string output = "";
            string Results = Search(itemname);
            if (Results == "True")
            {
                output = "All Items required found!";
            }
            else if (Results == "False")
            {
                output = "Missing Required Items!";
            }
            else
            {
                output = "Item Invalid";
            }
            return output ;
        }
            
    }
}
