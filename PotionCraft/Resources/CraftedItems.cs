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
                for(int x = 0; x <= 5; x++)
                {   
                        //Looks through each Item inside the List 
                        foreach (Item s in DatabaseOne)
                        {
                            System.Diagnostics.Debug.WriteLine("New the Foreach loop");
                             List<Item> Temporary = new List<Item>();
                            try
                            {
                                //If /else statment for creating dictionary based on s.Type
                                if (s.Type == "KEY=")
                                {
                                    Key = s;

                                    System.Diagnostics.Debug.WriteLine("S does CONTAIN KEY= " + Key.Name + s.Type + s.QuantityType);
                                }
                                else if (s.Type == "VALUE=")
                                {
                                    Temporary.Add(new Item()
                                    {
                                        Name = s.Name,
                                        Description = s.Description,
                                        Quantity = s.Quantity,
                                        Price = s.Price,
                                        QuantityType = s.QuantityType,

                                    });

                                    System.Diagnostics.Debug.WriteLine("S does CONTAIN VALUE= " + s.Name + s.Type + s.QuantityType + Temporary.Count);
                                }
                                else if (s.Type == "END")
                                {
                                    for (int i = 0; i < Temporary.Count; i++)
                                    {
                                        System.Diagnostics.Debug.WriteLine("S =" + Key.Name + Temporary[i].Name + Temporary.Count);
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
            //For each Item, List<ITEM> pair in Dictionary
            foreach (KeyValuePair<Item, List<Item>> x in DataBaseItems)
            {
                System.Diagnostics.Debug.WriteLine("DICTIONARY LIST IS HERE " + x.Value.Count);
                output += $"ITEM: {x.Key.Name} {x.Key.Description} {Environment.NewLine}";
                item = x.Value; 
                output += "RECIPE: ";
                foreach (Item s in item)
                {
                   
                    output += $"{s.Name}, ";
                    

                    System.Diagnostics.Debug.WriteLine("THE OUTPUT IS HERE" + item.Count);
                }
                  

                System.Diagnostics.Debug.WriteLine("Output is here" + output);


               

            } 
            return output;
        }
    }
}

