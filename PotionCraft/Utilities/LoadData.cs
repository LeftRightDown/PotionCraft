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
            
            //temp list
            List<Item> Lines = new List<Item>();
            foreach (string s in File.ReadAllLines(path))
            {
                string[] Key = s.Split('~');
                string[] Value = s.Split(',');
                Item i = new Item();   
                Recipe x = new Recipe();
                if (s.Contains("KEY="))
                {
                    i.Name = Key[1];
                    i.Quantity = float.Parse(Key[2]);
                    i.Description = Key[3];
                    i.Price = float.Parse(Key[4]);
                    
                }
                else if (s.Contains("VALUE="))
                {

                    i.FormulaName= Value[2];
                    i.FormulaQuantity = float.Parse(Value[1]);

                }
                Lines.Add(i);
            }
            return Lines;
        }
    }
}

