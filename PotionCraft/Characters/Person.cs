using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PotionCraft
{
    public class Person
    {

        public string Name { get; set; } = string.Empty;
        public  float Currency { get; set; }

        public delegate float CurrencyMath(float currency, float item);

        //Adds Money points to Person instance depeneding on Item price
        public float CurrencyAdd (float currency, float item)
        {
            System.Diagnostics.Debug.WriteLine("BEFORE TOTAL" + currency + item);
            
            float sum = currency + item;
            System.Diagnostics.Debug.WriteLine("AFTER TOTAL" + sum);


            return sum;
        }

        //Removes Money points from Person instance depending on Item price
        public  float CurrencySubtract(float currency,float item)
        {
            System.Diagnostics.Debug.WriteLine("BEFORE TOTAL" + currency + item);
        
            float sum = currency - item;
            System.Diagnostics.Debug.WriteLine("AFTER TOTAL" + currency + item);


            return sum;
        }


        //Universal Buy and Sell method for Each person child class
        public void Buy(string itemName, Person Seller, Person Buyer,List<Item> SellerList, List<Item> BuyerList)
        {
            CurrencyMath Add = CurrencyAdd;
            CurrencyMath Subtract = CurrencySubtract;
           
            Item Results = Utility.SearchInventory(itemName, SellerList);
            if (Results.Name == itemName)
            {
                if (Buyer.Currency >= Results.Price)
                {
                   
                    BuyerList.Add(Results);
                    SellerList.Remove(Results);
                    
                   
                    System.Diagnostics.Debug.WriteLine("BEFORE SELLER" + Seller.Currency);

                    Seller.Currency = Add(Seller.Currency, Results.Price);

                    System.Diagnostics.Debug.WriteLine("AFTER SELLER" + Seller.Currency);
                    Buyer.Currency = Subtract(Buyer.Currency, Results.Price);
                }
                else if (Buyer.Currency < Results.Price)
                {
                    MessageBox.Show("Invalid Amount");
                }
                
            }


        }

        public void Sell(string itemName, Person Seller, Person Buyer, List<Item> SellerList, List<Item> BuyerList)
        {

            Item Results = Utility.SearchInventory(itemName, SellerList);
            if (Results == null)
            {
                MessageBox.Show("No Valid Item");
            }
            else if (Results.Name == itemName)
            {
                if (Buyer.Currency >= Results.Price)
                {
                    BuyerList.Add(Results);
                    SellerList.Remove(Results);
                    System.Diagnostics.Debug.WriteLine("BEFORE SELLER" + Seller.Currency);

                    Seller.Currency = CurrencyAdd(Seller.Currency, Results.Price);

                    System.Diagnostics.Debug.WriteLine("AFTER SELLER" + Seller.Currency);
                    Buyer.Currency = CurrencySubtract(Buyer.Currency, Results.Price);
                }
                else if (Buyer.Currency < Results.Price)
                {
                    MessageBox.Show("Invalid Amount");
                }

            }

        }  
    }
}