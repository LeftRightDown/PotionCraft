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


        public static string[] LoadLinesFromFile(string path)
        {

            //temp list
            List<Item> item = new List<Item>();
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
                   i.Formula.Name = Value[2];
                   i.Formula.Quantity = float.Parse(Value[1]);
                    
                    item.add(i);
                }
                  
            }
            return File.ReadAllLines(path);
        }
    }
}

