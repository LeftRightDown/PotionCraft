using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    public class Utility
    {
        //Prints Text to Specific Box (Class WPF DEMO)
        public static void PrintMain(string output)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainText.Text = output;
           
        }

        public static void PrintSide(string output)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).SideText.Text = output;
            
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



        public static string Search(string ItemName)
        {
            string output = "";
            IEnumerable<Item> Search = from n in Player.PlayerInventory where n.Name.Contains(ItemName)
                                       select n;

            foreach (Item x in Search)
            {
                if (x.Name == ItemName)
                {
                    output = "True";
                    System.Diagnostics.Debug.WriteLine(output + x.Name + ItemName);
                }
                else if (x.Name != ItemName)
                {
                    output = "False";
                    System.Diagnostics.Debug.WriteLine(output + x.Name + ItemName);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(output + x.Name + ItemName);
                    output = "Does Not Exist";
                }
              
            }   return output;
        }

    }
}
