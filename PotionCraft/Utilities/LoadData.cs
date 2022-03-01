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


        public static List<Material> LoadLinesFromFile(string path)
        {
            //temp list of items
            List<Material> items = new List<Material>();
            foreach (string s in File.ReadAllLines(path))
            {
                string[] subs = s.Split('~');

                Material i = new Material();
                i.Name = subs[1];
                i.Quantity = float.Parse(subs[0]);

                items.Add(new Material() { Name = s });
            }
            return items;
        }
    }
}

