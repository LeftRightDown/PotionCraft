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
            //List<string> lines2 = new List<string>();
            //string[] line= Lines.ToArray();
            foreach (string s in File.ReadAllLines(path))
            {
               
                string[] Key = s.Split('~');
                string[] Value = s.Split(',');
                Item i = new Item();
                Item x = new Item();

                if (s.Contains("KEY="))
                {
                    i.Type = Key[0];
                    i.Name = Key[1];
                    i.Quantity = float.Parse(Key[2]);
                    i.Description = Key[3];
                    i.Price = float.Parse(Key[4]);


                    System.Diagnostics.Debug.WriteLine("THE KEY: " + i.Name + i.Type);
                }
                else if (s.Contains("VALUE="))
                {
                    i.Type = Value[0];
                    i.Name = Value[2];
                    i.Quantity = float.Parse(Value[1]);
                    i.Description = Value[3];
                    i.Price = float.Parse(Value[4]);

                    System.Diagnostics.Debug.WriteLine("THE VALUE: " + i.Name + i.Type);
                    //System.Diagnostics.Debug.WriteLine("THE VALUE: " + Lines.Count);
                }
                else if (s.Contains("END"))
                {
                    i.Type = Key[0];
                }
               
                Lines.Add(i);             
                
            }
            return Lines ;
        }
    }
}

