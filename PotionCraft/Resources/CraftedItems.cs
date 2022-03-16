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
        public static Dictionary<Item, List<Item>> DataBaseItems = new Dictionary<Item, List<Item>>();
        public static List<Item> ListItem = new List<Item>();


        //Extracting Items from External data  (Assitance from Mack)
        public static void SetUpItems()
        {
            //ListItem = Recipes.SelectMany(d => d.Value).ToList();

            List<Item> DatabaseOne = LoadData.LoadLinesFromFile("../../../data/Crafteditems.txt");

           
            List<Item> Temporary = new List<Item>();
            
            
            foreach (Item s in DatabaseOne)
            {
                System.Diagnostics.Debug.WriteLine("New the Foreach loop");

                //If /else statment
                //if (s.Type == "KEY=")
                //{
                //    s.Name
                //    System.Diagnostics.Debug.WriteLine("S does CONTAIN KEY= " + Key + s.Type);
                //}
                if (s.Type == "VALUE=")
                {

                    Temporary.Add(new Item()
                    {

                        Name = s.Name,
                        Description = s.Description,
                        Quantity =s.Quantity,
                        Price = s.Price

                    });
                    System.Diagnostics.Debug.WriteLine("S does CONTAIN VALUE= " + s.Name + s.Type);
                }
                else if (s.Type == "END")
                {

                    DataBaseItems.Add(s, Temporary);
                    for (int i = 0; i < Temporary.Count; i++)
                    {
                        System.Diagnostics.Debug.WriteLine("S =" + s.Name + Temporary[i].Name);
                    }
                    Temporary.Clear();
                }   
                System.Diagnostics.Debug.WriteLine("Contains:" + Temporary.Count);

            }


        }



        //Method Displays the Dictionary of Key: Name and Value: Items (Recipies)
        public string ListDictionary()
        {
            string output = "";

            foreach (var s in DataBaseItems.Keys)
            {
                output += $"{s.Name} s {s.Description} {Environment.NewLine}";
            }

            //foreach (KeyValuePair<Item, List<Item>> x in List)
            //{
            //    output+= $"{x.Key.Name} {x.Key.Description}";

            //    x.Value.ForEach(delegate (Item item)
            //    {


            //        output += $" {item.Name} {item.Description} {Environment.NewLine}";

            //    });


            //    System.Diagnostics.Debug.WriteLine("THE OUTPUT IS HERE" + output);
            //}

            //foreach (var item in List.Keys)
            //{
            //    output += $" {item} s {item.Description} {Environment.NewLine}";
            //}

            System.Diagnostics.Debug.WriteLine("OutPut is here" + output);


            return output;

        }
    }
}

