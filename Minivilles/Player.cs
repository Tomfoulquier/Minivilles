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
        Pile playerCity = new Pile();
        #endregion

        #region methode
        public Player()
        {
        }

        public void BuyCard(Pile playerCity,Card card)
        {
            if (coins < card.price)
            {
                Console.WriteLine("Vous n'avez pas assez d'argent pour l'acheter.");
            }
            else
            {
                playerCity.AddCard(card);
                coins -= card.price;
            }
        }
        #endregion
    }
}
