using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minivilles
{
    public class Die
    {
        Random rand = new Random();
        bool doubleDie = false; //utiliser 2 dés ou non
        public Die() 
        {
            
        }

        public int LaunchDie(bool doubledie)
        {
            int result;
            if (doubledie)
            {
                result = rand.Next(6);
            }
            else
            {
                result = rand.Next(12);
            }
            return result;
        }
    }
}
