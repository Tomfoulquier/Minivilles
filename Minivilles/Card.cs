using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minivilles
{
    public class Card
    {
        public int activationNumber;
        public string effect;
        public int price;

        public Card(int _activationNumber, string _effect, int _price) 
        {
        
            activationNumber = _activationNumber;
            effect = _effect;
            price = _price;
        
        }

    }

}
