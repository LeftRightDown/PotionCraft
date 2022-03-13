using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Material: Item
    { 
        
        
        public static List<Item> Ingredients = LoadData.LoadLinesFromFile("../../../data/Ingredients.txt");
       
        public Material(string name, string description, float quantity)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
        }


       
    }
}