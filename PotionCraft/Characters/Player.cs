using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    public class Player: Person, ICraft
    {
         

        public string Name { get; set; }
        public float Currency { get; set; }

        public Player()
        {


        }

        

        void ICraft.Craft(Recipe recipe)
        {


        }

    }
}
