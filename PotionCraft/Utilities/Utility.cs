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
        public static void Print(string output)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainText.Text = output;
            //((MainWindow)System.Windows.Application.Current.MainWindow.Content).MainText.Text = output;
        }


        public static void Display(List<Item> list)
        {
           list.ForEach(item => Console.WriteLine(item.ToString()));
            
        }

    }
}
