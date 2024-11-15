using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minivilles
{

    public class Game
    {

        public List<Player> listJoueurs;
        public List<int> stockCards;
        public Pile referenceCards;
        public bool isPlayerTurn;
        public bool endGame;

        public Game()
        {

            listJoueurs.Add(new Player());
            listJoueurs.Add(new Player());

            for (int i = 0; i < 8; i++) 
            {

                stockCards.Add(6);

            }

            referenceCards = new Pile();
            // A FAIRE : Ajouter les Cards a Pile
            referenceCards.AddCard();
            referenceCards.AddCard();
            referenceCards.AddCard();
            referenceCards.AddCard();
            referenceCards.AddCard();
            referenceCards.AddCard();
            referenceCards.AddCard();
            referenceCards.AddCard();

            isPlayerTurn = true;
            endGame = false;

        }

    }

}
