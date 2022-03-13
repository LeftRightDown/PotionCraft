using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PotionCraft
{
    public class CraftedItems : Item
    {


        //Items w/Dictionary Collection
        public static Dictionary<string, List<Item>> DataBaseItems = new Dictionary<string, List<Item>>();
        public static List<Item> ListItem = new List<Item>();


        //Extracting Items from External data  (Assitance from Mack)
        public void SetUpItems()
        {
            //ListItem = Recipes.SelectMany(d => d.Value).ToList();

            List<Item> DatabaseOne = LoadData.LoadLinesFromFile("../../../data/Crafteditems.txt");

            string Key = "";
            List<Item> Temporary;


            foreach (Item s in DatabaseOne)
            {

                System.Diagnostics.Debug.WriteLine("New the Foreach loop");
                Temporary = new List<Item>();

                

                if (s.Type == "KEY=")
                {
                    Key = s.Name;
                    System.Diagnostics.Debug.WriteLine("S does CONTAIN KEY= " + Key + s.Type);
                    //s.Name = DatabaseOne[i].Name;
                    //s.Description = DatabaseOne[i].Description;
                    //s.Quantity = DatabaseOne[i].Quantity;
                    //s.Price = DatabaseOne[i].Price;

                }
                else if (s.Type == "VALUE=")
                {
                    //Temporary.Add(s);

                    Temporary.Add(new Item()
                    {

                        Name = DatabaseOne[2].Name,
                        Description = DatabaseOne[3].Description,
                        Quantity = DatabaseOne[1].Quantity,
                        Price = DatabaseOne[4].Price

                    });
                    System.Diagnostics.Debug.WriteLine("S does CONTAIN VALUE= " + s.Name + s.Type);
                }
                else if (s.Type == "END")
                {

                    DataBaseItems.Add(Key, Temporary);
                    for (int i = 0; i < Temporary.Count; i++)
                    {
                        System.Diagnostics.Debug.WriteLine("S =" + Key + Temporary[i].Name);
                    }
                }   
                System.Diagnostics.Debug.WriteLine("Contains:" + Temporary.Count);

            }


        }







        public string ListDictionary(Dictionary<string, List<Item>> List)
        {
            string output = "";


            foreach (KeyValuePair<string, List<Item>> x in List)
            {
                x.Value.ForEach(delegate (Item item)
                {


                    output += $" {item.Description} {Environment.NewLine}";

                });


                System.Diagnostics.Debug.WriteLine("THE OUTPUT IS HERE" + output);
            }
            return output;

        }
    }
}

