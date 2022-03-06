using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PotionCraft
{
    public class LoadData
    {
        public static string LoadTextFromFile(string path)
        {
            return File.ReadAllText(path);
        }


        public static List<Item> LoadLinesFromFile(string path)
        {
            //temp list of items
            List<Item> items = new List<Item>();
            foreach (string s in File.ReadAllLines(path))
            {
                string[] Key = s.Split('~');
                string[]  Value = s.Split(',');
                Item i = new Item();
                if (s.Contains("KEY="))
                {
                    i.Name = Key[1];
                    i.Quantity = float.Parse(Key[0]);
                    i.Description = Key[2];
                    i.Price = float.Parse(Key[3]);
                    
                }
                else if (s.Contains("VALUE="))
                {
                   i.Formula.Name = Value[1];
                   i.Formula.Quantity = Value[2];
                }
              
                
                

                items.Add(new Item() { Name = s });     
            }
            return items;
        }
    }
}

