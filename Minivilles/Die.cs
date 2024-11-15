﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minivilles
{
    public class Die
    {
        Random rand = new Random();
        public Die()
        {
        }

        public int RollDie(bool doubleDie)
        {
            int result;
            if (!doubleDie)
            {
                result = rand.Next(1,7);
            }
            else
            {
                result = rand.Next(1,13);
            }
            return result;
        }
    }
}
