using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PotionCraft.CraftedItems;


namespace PotionCraft
{
    public class Utility
    {
      
        //Prints Text to Specific Box (Class WPF DEMO)
        public static void PrintMain(string output)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainText.Text = output;
           
        }

        

        public static string DisplayList(List<Item> list)
        {
            string output = "";
           //list.ForEach(item => Console.WriteLine(item.ToString()));
            
            
            for (int i = 1; i <= list.Count; i++)
            {
               foreach( Item s in list)
               {
                output +=$"({i}) Item: {s.Name} ({s.Price.ToString("C")}){Environment.NewLine}Description: {s.Description}{Environment.NewLine} {Environment.NewLine}";  
               }

            }
            return output;
        }

        public static void SetUpCharacters(string name,List<Item> list)
        {
            if (name == "Player")
            {
                Player.PlayerInventory = list;
            }
            else if (name == "Vendor")
            {
                Vendor.VendorInventory = list;
               
            }
        }

        // method that searches PEARSONS inventory for items
        public static Item SearchInventory(string ItemName,List<Item> list )
        {
            Item w = null;
            //IEnumerable<Item> Search = from n in list
            //                             where n.Name.Contains(ItemName)
            //                           select n;
            IEnumerable<Item> Search = list
                                .Where(n => n.Name.Contains(ItemName));
            System.Diagnostics.Debug.WriteLine("HERE IS ITEMS BEING PASSED: " + ItemName);
            foreach (Item x in Search)
            {
            
                if (x.Name != ItemName)
                {
                    return null;
                    
                }
                 return x;
            }
            return w;


        }

        // method that searches database for the key returning the values (list) 
        public static List<Item> SearchDatabse(string ItemName)
        {
            string output = "";
            List<Item> Recipe = new List<Item>();
            IEnumerable<Item> Search = from n in DataBaseItems.Keys
                                       where n.Name.Contains(ItemName)
                                       select n;
            System.Diagnostics.Debug.WriteLine("HERE IS ITEMS BEING PASSED: " + ItemName + DataBaseItems.Keys);
            
            foreach(Item Key in Search)
            {
                if (Key.Name == ItemName)
                {
                    foreach (KeyValuePair<Item, List<Item>> x in DataBaseItems)
                    {
                        return x.Value;
                        System.Diagnostics.Debug.WriteLine("ITEMS BEING CHECKED " + x.Value  + ItemName);
                    }
                }
             
            }
            return Recipe; 
       
            

           
        }


    }
}
