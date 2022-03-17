using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotionCraft
{
    public class Person
    {

        public string Name { get; set; } = string.Empty;
        public  float Currency { get; set; }

        //Adds Money points to Person instance depeneding on Item price
        public float CurrencyAdd (float currency, float item)
        {
            item = 5;
            float sum = currency + item;

            

            return sum;
        }

        //Removes Money points from Person instance depending on Item price
        public  float CurrencyRemove(float currency,float item)
        {
            item = 5;
            float sum = currency - item;



            return sum;
        }



        public void BuyandSell(string itemName, List<Item> SellerList, List<Item> BuyerList)
        {
           
            Item Results = Utility.SearchInventory(itemName, SellerList);
              BuyerList.Add(Results);
              SellerList.Remove(Results);
            System.Diagnostics.Debug.WriteLine("HERE ARE buy results"+ Results.Name);
              
        }

        //public  void Sell(string itemName, List<Item> SellerList, List<Item> BuyerList)
        //{
        //    Item sellResults = Utility.SearchInventory(itemName, SellerList);
        //    BuyerList.Remove(sellResults);

        //    System.Diagnostics.Debug.WriteLine("HERE ARE buy results" + sellResults);
        //}

        //bool SearchInventory(Item word)
        //{

        //    return;
        //}

    }
}