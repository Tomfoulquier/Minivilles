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
        public Random random = new Random();

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
            referenceCards.AddCard(new Card(2, "0,2", 1, "Boulangerie"));
            referenceCards.AddCard(new Card(1, "0,1", 2, "Champs de blé"));
            referenceCards.AddCard(new Card(1, "0,1", 2, "Ferme"));
            referenceCards.AddCard(new Card(3, "1,1", 2, "Café"));
            referenceCards.AddCard(new Card(4, "0,3", 2, "Superette"));
            referenceCards.AddCard(new Card(5, "0,1", 2, "Forêt"));
            referenceCards.AddCard(new Card(5, "1,2", 4, "Restaurant"));
            referenceCards.AddCard(new Card(6, "0,4", 6, "Stade"));

            isPlayerTurn = true;
            endGame = false;

            listJoueurs[0].playerCity.AddCard(referenceCards.listCards[0]);
            listJoueurs[0].playerCity.AddCard(referenceCards.listCards[1]);

            listJoueurs[1].playerCity.AddCard(referenceCards.listCards[0]);
            listJoueurs[1].playerCity.AddCard(referenceCards.listCards[1]);

            Console.WriteLine("MINIVILLE");
            Console.WriteLine();

            while (!endGame) 
            {

                int resultDie;

                if (isPlayerTurn) 
                {

                    Console.WriteLine("Tour : Joueur");
                    Console.WriteLine();

                    Console.Write("Cartes Joueur : ");
                    foreach ( Card card in listJoueurs[0].playerCity.listCards)
                    {

                        Console.Write(card.name + " ; ");

                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.Write("Cartes IA : ");
                    foreach ( Card card in listJoueurs[1].playerCity.listCards)
                    {

                        Console.Write(card.name + " ; ");

                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("Appuyez sur entrer pour lancer le dés");
                    Console.ReadLine();

                    resultDie = die.RollDie(false);

                    Console.WriteLine("dés tirer : {0}", resultDie);

                    foreach (Card card in listJoueurs[0].playerCity.listCards) 
                    {
                    
                        if(card.activationNumber == resultDie) 
                        {

                            ApplyEffect(0, card.effect);

                        }
                    
                    }

                    foreach (Card card in listJoueurs[1].playerCity.listCards)
                    {

                        if (card.activationNumber == resultDie && card.effect.Split(",")[0] == "1")
                        {

                            ApplyEffect(1, card.effect);

                        }

                    }



                    Console.WriteLine("piece Joueur : " + listJoueurs[0].coins);
                    Console.WriteLine("piece IA : " + listJoueurs[1].coins);

                    isPlayerTurn = false;

                    Console.ReadLine();

                    int ii = 0;

                    Console.WriteLine("0. quitter la boutique");
                    if (stockCards[0] > 0) { ii++; Console.WriteLine("{0}. [2] Boulangerie - Recevez 2$ - 1$ | STOCK : {1} ", ii, stockCards[0]); }
                    if (stockCards[1] > 0) { ii++; Console.WriteLine("{0}. [1] Champs de blé - Recevez 1$ - 1$ | STOCK : {1} ", ii, stockCards[1]); }
                    if (stockCards[2] > 0) { ii++; Console.WriteLine("{0}. [1] Ferme - Recevez 1$ - 2$ | STOCK : {1} ", ii, stockCards[2]); }
                    if (stockCards[3] > 0) { ii++; Console.WriteLine("{0}. [3] Café - Recevez 1$ du joueur advairse - 2$ | STOCK : {1} ", ii, stockCards[3]); }
                    if (stockCards[4] > 0) { ii++; Console.WriteLine("{0}. [4] Superette - Recevez 3$ - 2$ | STOCK : {1} ", ii, stockCards[4]); }
                    if (stockCards[5] > 0) { ii++; Console.WriteLine("{0}. [5] Forêt - Recevez 1$ - 2$ | STOCK : {1} ", ii, stockCards[5]); }
                    if (stockCards[6] > 0) { ii++; Console.WriteLine("{0}. [5] Restaurant - Recevez 2$ du joueur advairse - 1$ | STOCK : {1} ", ii, stockCards[6]); }
                    if (stockCards[7] > 0) { ii++; Console.WriteLine("{0}. [6] Stade - Recevez 4$ - 6$ | STOCK : {1} ", ii, stockCards[7]); }

                    int choice = 55;

                    while (choice < 0 || choice > 8) 
                    {

                        Console.WriteLine("");
                        Console.WriteLine("Quelle carte ?");
                        choice = int.Parse(Console.ReadLine());

                        if (choice >= 1 && choice <= 8)
                        {

                            if (listJoueurs[0].coins >= referenceCards.listCards[choice - 1].price && stockCards[choice - 1] > 0 && choice != 0)
                            {

                                listJoueurs[0].BuyCard(referenceCards.listCards[choice - 1]);
                                Console.WriteLine("Carte Achetée");
                                stockCards[choice - 1]--;

                            }
                            else if (choice != 0)
                            {

                                Console.WriteLine("Vous n'avez pas assez d'argent");
                                choice = 55;

                            }
                            else
                            {

                                Console.WriteLine("Carte Acheté");

                            }
                        }
                        else if(choice == 0)
                        {

                            

                        }
                        else 
                        {

                            Console.WriteLine("Choix invalide");
                            choice = 55;

                        }



                    }
                    Console.WriteLine();

                }
                else 
                {
                    Console.WriteLine("Tour : IA ");
                    Console.ReadLine();


                    resultDie = die.RollDie(false);

                    Console.WriteLine("dés tirer : {0}", resultDie);

                    foreach (Card card in listJoueurs[1].playerCity.listCards)
                    {

                        if (card.activationNumber == resultDie)
                        {

                            ApplyEffect(1, card.effect);

                        }

                    }

                    foreach (Card card in listJoueurs[0].playerCity.listCards)
                    {

                        if (card.activationNumber == resultDie && card.effect.Split(",")[0] == "1")
                        {

                            ApplyEffect(0, card.effect);

                        }

                    }

                    Console.WriteLine("piece Joueur : " + listJoueurs[0].coins);
                    Console.WriteLine("piece IA : " + listJoueurs[1].coins);
                    Console.ReadLine();

                    if (random.Next(0, 2) == 1 && listJoueurs[1].coins > 0) 
                    {
                    
                        for (int i = referenceCards.listCards.Count-1; i >= 0; i--) 
                        {

                            int cardChoosen = random.Next(0, i+1);

                            if (stockCards[cardChoosen] > 0 && listJoueurs[1].coins >= referenceCards.listCards[i].price) 
                            {

                                listJoueurs[1].BuyCard(referenceCards.listCards[cardChoosen]);
                                stockCards[cardChoosen]--;
                                Console.WriteLine("Card Buy : " + referenceCards.listCards[cardChoosen].name);
                                Console.WriteLine(listJoueurs[1].playerCity.listCards.Count);
                                Console.ReadLine();

                                break;

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

            if(_effect.Split(",")[0] == "0") 
            {

                listJoueurs[indexPlayer].coins += int.Parse(_effect.Split(",")[1]);

            }
            else 
            {
            
                if(listJoueurs[inverseIndexPlayer].coins > int.Parse(_effect.Split(",")[1]))
                {

                    listJoueurs[indexPlayer].coins += int.Parse(_effect.Split(",")[1]);
                    listJoueurs[inverseIndexPlayer].coins -= int.Parse(_effect.Split(",")[1]);

                }
                else
                {

                    listJoueurs[indexPlayer].coins += listJoueurs[inverseIndexPlayer].coins;
                    listJoueurs[inverseIndexPlayer].coins = 0;

                }
            
            }
           



            


        }


    }

}
