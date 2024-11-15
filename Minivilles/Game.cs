using System;
using System.Collections;
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
        public Die die;
        public Random random = new Random;

        public Game()
        {

            listJoueurs = new List<Player>();
            referenceCards = new Pile();
            stockCards = new List<int>();
            die = new Die();

            listJoueurs.Add(new Player());
            listJoueurs.Add(new Player());

            for (int i = 0; i < 8; i++) 
            {



                stockCards.Add(6);

            }

            referenceCards = new Pile();
            referenceCards.AddCard(new Card(1, "0,1", 2, "Champs de blé"));
            referenceCards.AddCard(new Card(1, "0,1", 2, "Ferme"));
            referenceCards.AddCard(new Card(2, "0,2", 1, "Boulangerie"));
            referenceCards.AddCard(new Card(3, "1,1", 2, "Café"));
            referenceCards.AddCard(new Card(4, "0,3", 2, "Superette"));
            referenceCards.AddCard(new Card(5, "0,1", 2, "Forêt"));
            referenceCards.AddCard(new Card(5, "1,2", 4, "Restaurant"));
            referenceCards.AddCard(new Card(6, "0,4", 6, "Stade"));

            isPlayerTurn = true;
            endGame = false;

            listJoueurs[0].playerCity.AddCard(referenceCards.listCards[0]);
            listJoueurs[0].playerCity.AddCard(referenceCards.listCards[2]);

            listJoueurs[1].playerCity.AddCard(referenceCards.listCards[0]);
            listJoueurs[1].playerCity.AddCard(referenceCards.listCards[2]);

            while (!endGame) 
            {

                int resultDie;

                if (isPlayerTurn) 
                {

                    Console.Clear();
                    Console.WriteLine("Appuyez sur entrer pour lancer le dés");
                    Console.ReadLine();

                    resultDie = die.RollDie(false);

                    Console.Clear();
                    Console.WriteLine("Vous avez tirer le {0}", resultDie);

                    foreach (Card card in referenceCards.listCards) 
                    {
                    
                        if(card.activationNumber == resultDie) 
                        {

                            ApplyEffect(0, card.effect);

                        }
                    
                    }

                    Console.WriteLine("piece j : " + listJoueurs[0].coins);
                    Console.WriteLine("piece o : " + listJoueurs[1].coins);

                    isPlayerTurn = false;

                    Console.ReadLine();
                
                }
                else 
                {

                    if (random.Next(0, 2)) 
                    {
                    
                        for (int i = referenceCards.listCards.Count-1; i >= 0; i--) 
                        {

                            if (stockCards[i] > 0 && listJoueurs[1].coins >= referenceCards.listCards[i].price) 
                            {


                            
                            }
                        
                        }
                    
                    }
                    
                    isPlayerTurn = true;
                
                }
            
            }

        }

        public void ApplyEffect(int indexPlayer,  string _effect)
        {

            int inverseIndexPlayer;

            if(indexPlayer == 0) {  inverseIndexPlayer = 1; } else { inverseIndexPlayer = 0; }

            listJoueurs[indexPlayer].coins += int.Parse(_effect.Split(",")[1]);
            
            if (_effect.Split(",")[0] == "1") { listJoueurs[inverseIndexPlayer].coins -= int.Parse(_effect.Split(",")[1]);  }

            if(indexPlayer == 0) 
            {

                Console.WriteLine("Vous avez gagné {0} pieces", int.Parse(_effect.Split(",")[1]));
            
            }

            if(inverseIndexPlayer == 0 && _effect.Split(",")[0] == "1") 
            {

                Console.WriteLine("Vous avez perdu {0} pieces", int.Parse(_effect.Split(",")[1]));

            }
            


        }


    }

}
