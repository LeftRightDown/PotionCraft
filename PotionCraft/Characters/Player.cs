using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    public class Player: Person, ICraft
    {

        public Player(string name, float currency)
        {
            Name = name;
            Currency = currency;

        }

        

        void ICraft.Craft()
        {


        }

    }
}
