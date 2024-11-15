using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Minivilles
{
    public class Player
    {
        #region atribute
        public int coins = 3;
        #endregion

        #region methode
        public Player()
        {
            Pile playerCity = new Pile();
        }

        public void BuyCard()
        {
            Pile playerCity = new Pile();
            playerCity.AddCard()

        }

        public void DiceRolling()
        {

        }
        #endregion
    }
}
