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
        //Google how setting list into another list works
        public static void SetUpItems()
        {
            //ListItem = Recipes.SelectMany(d => d.Value).ToList();

            List<Item> DatabaseOne = LoadData.LoadLinesFromFile("../../../data/Crafteditems.txt");

            Item Key = new Item();    

            foreach (Item s in DatabaseOne)
            { 
                System.Diagnostics.Debug.WriteLine("New the Foreach loop");
                List<Item> Temporary = new List<Item>();

                for (int z = 0; z <= DataBaseItems.Keys.Count; z++)
                {
                    try
                    { 
                        //If /else statment
                        if (s.Type == "KEY=")
                        {
                            Key = s;

                            System.Diagnostics.Debug.WriteLine("S does CONTAIN KEY= " + Key.Name + s.Type);
                        }
                        else if (s.Type == "VALUE=")
                        {

                            Temporary.Add(new Item()
                            {
                                Name = s.Name,
                                Description = s.Description,
                                Quantity = s.Quantity,
                                Price = s.Price

                            });

                            System.Diagnostics.Debug.WriteLine("S does CONTAIN VALUE= " + s.Name + s.Type);
                        }
                        else if (s.Type == "END")
                        {

                            for (int i = 0; i < Temporary.Count; i++)
                            {
                                System.Diagnostics.Debug.WriteLine("S =" + Key.Name + Temporary[i].Name);
                            }
                            DataBaseItems.Add(Key, Temporary);
                            System.Diagnostics.Debug.WriteLine("Contains TEMP LIST SOEMTHING :  " + Temporary.Count);

                            System.Diagnostics.Debug.WriteLine("Contains:" + Temporary.Count);
                        }
                    }
                    catch (ArgumentException)
                    {


                        Key = null;
                    }
                }

            }
            foreach (KeyValuePair<Item, List<Item>> w in DataBaseItems)
            {
                System.Diagnostics.Debug.WriteLine("THIS IS NEW" + w.Value.Count );
            }

                
        }

        


        //Method Displays the Dictionary of Key: Name and Value: Items (Recipies)
        public static string ListDictionary()
        {
            string output = "";

            List<Item> item = new List<Item>();

            foreach (KeyValuePair<Item, List<Item>> x in DataBaseItems)
            {
                System.Diagnostics.Debug.WriteLine("DICTIONARY LIST IS HERE " + x.Value.Count);
                output += $"{x.Key.Name} {x.Key.Description} {Environment.NewLine}";
                item = x.Value;
                foreach (Item s in item)
                {
                    output += $"{s.Name} {s.Description}{Environment.NewLine}";
                    


                    System.Diagnostics.Debug.WriteLine("THE OUTPUT IS HERE" + item.Count);
                }

                //foreach (var item in List.Keys)
                //{
                //    output += $" {item} s {item.Description} {Environment.NewLine}";
                //}

                System.Diagnostics.Debug.WriteLine("Output is here" + output);


               

            } 
            return output;
        }
    }
}

