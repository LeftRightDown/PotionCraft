﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraft
{
    interface ICraft
    {
       Item Craft(Item itemname)
        {
            return itemname;
        }
    }
}
