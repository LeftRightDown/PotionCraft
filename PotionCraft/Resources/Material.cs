using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Material: Item
    { 
        
        
        public static List<Item> Ingredients = LoadData.LoadLinesFromFile("../../../data/Ingredients.txt");

        public static List<Item> StarterIngredients = LoadData.LoadLinesFromFile("../../../data/StarterKit.txt");

       
    }
}