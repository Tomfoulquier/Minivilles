﻿using System;
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
            referenceCards.AddCard(new Card(1, "01", 2, "Champs de blé"));
            referenceCards.AddCard(new Card(1, "01", 2, "Ferme"));
            referenceCards.AddCard(new Card(2, "02", 1, "Boulangerie"));
            referenceCards.AddCard(new Card(3, "11", 2, "Café"));
            referenceCards.AddCard(new Card(4, "03", 2, "Superette"));
            referenceCards.AddCard(new Card(5, "01", 2, "Forêt"));
            referenceCards.AddCard(new Card(5, "12", 4, "Restaurant"));
            referenceCards.AddCard(new Card(6, "04", 6, "Stade"));

            isPlayerTurn = true;
            endGame = false;

        }

    }

}
