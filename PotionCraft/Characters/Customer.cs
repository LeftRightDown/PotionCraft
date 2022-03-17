using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
   public class Customer: Person
    {
       public List<Item> BoughtItems = new List<Item>();
        public Customer(string name, float currency)
        {
            Name = name;
            Currency = currency;
        }
    }
}
