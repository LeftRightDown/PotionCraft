using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Material: Item
    {
        public Material(string name, string description, float quantity)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
        }


        List<Item> Ingredients = LoadData.LoadLinesFromFile("../../Ingredients.txt");
    }
}