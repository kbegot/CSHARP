﻿using System;

namespace Csharp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        
        static void Main(string[] args)
        {            
            char[,] board = new char[3, 3]
                {
                    { ' ', ' ', ' ', },
                    { ' ', ' ', ' ', },
                    { ' ', ' ', ' ', },
                };
            bool result = false;
            bool playerTurn = true;
            while(true)
            {
                
                Console.WriteLine("Bienvenue sur le jeu du Morpion: \n[1] pour lancer une partie. \n[2] pour lire les régles \n[3] Quitter");

                string choiceMenu = Console.ReadLine();

                switch (choiceMenu)
                {
                    case "1" :
    
                        Console.Clear();
                        Console.WriteLine("Création du premier joueur: ");
                        Personne player1 = CreatePlayer();

                        Console.Clear();
                        Console.WriteLine("Création du deuxième joueur: ");
                        Personne player2 = CreatePlayer();

                        Console.Clear();
                        Console.WriteLine("Appuiez sûr [Enter] pour lancer de la partie: ("+player1.Prenom +" vs "+ player2.Prenom +")");
                        Console.ReadLine();

                        GameEngine.Start(result, board, playerTurn, player1, player2);
                        break;  

                    case "2" : 
                        Console.Clear();
                        Console.WriteLine("Règle du jeu : \n\nLe morpion ce joue sur une grille de 3 cases sur 3.");
                        Console.WriteLine("Le but du jeu est d’aligner avant son adversaire 3 symboles identiques horizontalement, verticalement ou en diagonale."); 
                        Console.WriteLine("Attention, le joueur qui débute est toujours avantagé pour gagner. Pensez donc à alterner !");  
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3" :
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                    Console.Clear();
                    Console.WriteLine("Veuilliez rentrez un chiffre valide");
                    break;
                }        
            }
            Personne CreatePlayer()
            {
                string prenom;
                Console.WriteLine("\nRentrez votre Prénom: ");
                prenom = Console.ReadLine();
                Personne p = new Personne(prenom, 0);
                return p;
            } 

        }
        
    }
}
