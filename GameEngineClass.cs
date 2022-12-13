using System;

namespace Csharp // Note: actual namespace depends on the project name.
{
    public static class GameEngine
    {   


        public static void Start(bool result, char[,] board, bool playerTurn, Personne player1, Personne player2) 
        {
               while (!result)
                            {
                                board = new char[3, 3] //initialisation de la grille
                                {
                                    { ' ', ' ', ' ', },
                                    { ' ', ' ', ' ', },
                                    { ' ', ' ', ' ', },
                                };
                                while (!result)
                                {
                                    
                                    if (playerTurn)
                                    {
                                        Player1Turn(result, board);
                                        if (WinCondition('X', board)) // if X retrun true in WinCondition then the player1 scores 1 point. Displays the score of the players
                                        {
                                            End("\n" + player1.Prenom + " à gagné et marque 1 point!", board);
                                            player1.Score += 1;
                                            Console.WriteLine("\n" + player1.Prenom + ": " + player1.Score + " Poin(s)\n" + player2.Prenom + ": " + player2.Score + " Point(s)");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Player2Turn(result, board);
                                        if (WinCondition('O', board)) // if O retrun true in WinCondition then the player2 scores 1 point. Displays the score of the players
                                        {
                                            End("\n" + player2.Prenom + " à gagné et marque 1 point!", board);
                                            player2.Score += 1;
                                            Console.WriteLine("\n" + player1.Prenom + ": " + player1.Score + " Poin(s)\n" + player2.Prenom + ": " + player2.Score + " Point(s)");
                                            break;
                                        }
                                    }
                                    playerTurn = !playerTurn;
                                    if (FullBoard(board)) // if the FullBoard is true then equality. Displays the score of the players
                                    {
                                        End("égalité", board);
                                        Console.WriteLine("\n" + player1.Prenom + ": " + player1.Score + " Poin(s)\n" + player2.Prenom + ": " + player2.Score + " Point(s)");
                                        break;
                                    }
                                }                         
                                if (!result)
                                {
                                    Console.WriteLine("\nRejouer [enter] | Quitter [Q]");
                                GetInput:
                                    switch (Console.ReadKey(true).Key)
                                    {
                                        case ConsoleKey.Enter: break; // Can play again
                                        case ConsoleKey.Q: // Quit app
                                            Console.Clear();
                                            Environment.Exit(0);
                                            break;
                                        default: goto GetInput;
                                    }
                                }
                            }
        }

        private static bool FullBoard(char[,] board) // check if the table is complete and return true or false
        {
            if(
            board[0, 0] != ' ' && board[1, 0] != ' ' && board[2, 0] != ' ' && board[0, 2] != ' ' && board[1, 2] != ' ' && board[2, 2] != ' ' && board[0, 1] != ' ' && board[1, 1] != ' ' && board[2, 1] != ' ')
            {
                return true;
            } else {
                return false;
            }
        }

        
        private static void Player2Turn(bool result, char[,] board) // Management of player 1's turn
        {
            var (row, column) = (0, 0);
                bool move = false;
                while (!move && !result)
                {
                    Console.Clear();
                    Board(board);
                    Console.SetCursorPosition(column * 6 + 1, row * 4 + 1); // Set cursor position
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow: row = row <= 0 ? 2 : row - 1; break; // Move the cursor with the arrows to be able to put its cross
                        case ConsoleKey.DownArrow: row = row >= 2 ? 0 : row + 1; break;
                        case ConsoleKey.LeftArrow: column = column <= 0 ? 2 : column - 1; break;
                        case ConsoleKey.RightArrow: column = column >= 2 ? 0 : column + 1; break;
                        case ConsoleKey.Enter:
                            if (board[row, column] is ' ') // Fill the table if it is empty
                            {
                                board[row, column] = 'O'; 
                                move = true;
                            }
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            result = true;
                            break;
                    }
                }
        }

        private static void End(object value,char[,] board) // Display a message
        {
            Console.Clear();
            Board(board);
            Console.WriteLine();
            Console.Write(value);
        }
        private static void Board(char[,] board) // Initialization and display of the table
        {
            Console.WriteLine($" {board[0, 0]}  ║  {board[0, 1]}  ║  {board[0, 2]}");
            Console.WriteLine("    ║     ║");
            Console.WriteLine(" ═══╬═════╬═══");
            Console.WriteLine("    ║     ║");
            Console.WriteLine($" {board[1, 0]}  ║  {board[1, 1]}  ║  {board[1, 2]}");
            Console.WriteLine("    ║     ║");
            Console.WriteLine(" ═══╬═════╬═══");
            Console.WriteLine("    ║     ║");
            Console.WriteLine($" {board[2, 0]}  ║  {board[2, 1]}  ║  {board[2, 2]}");
        }
        private static bool WinCondition(char k, char[,] board) // check if there is a win condition and return true or false
        {
            if(
            board[0, 0] == k && board[1, 0] == k && board[2, 0] == k ||board[0, 1] == k && board[1, 1] == k && board[2, 1] == k ||
            board[0, 2] == k && board[1, 2] == k && board[2, 2] == k ||board[0, 0] == k && board[0, 1] == k && board[0, 2] == k ||
            board[1, 0] == k && board[1, 1] == k && board[1, 2] == k ||board[2, 0] == k && board[2, 1] == k && board[2, 2] == k ||
            board[0, 0] == k && board[1, 1] == k && board[2, 2] == k ||board[2, 0] == k && board[1, 1] == k && board[0, 2] == k)
            {
                return true;
            } else{
                return false;
            }
        }

        private static void Player1Turn(bool result, char[,] board) // Management of player 2's turn
        {
            var (row, column) = (0, 0);
                bool move = false;
                while (!move && !result)
                {
                    Console.Clear();
                    Board(board);

                    Console.SetCursorPosition(column * 6 + 1, row * 4 + 1); // Set cursor position
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow: row = row <= 0 ? 2 : row - 1; break; // Move the cursor with the arrows to be able to put its cross
                        case ConsoleKey.DownArrow: row = row >= 2 ? 0 : row + 1; break;
                        case ConsoleKey.LeftArrow: column = column <= 0 ? 2 : column - 1; break;
                        case ConsoleKey.RightArrow: column = column >= 2 ? 0 : column + 1; break;
                        case ConsoleKey.Enter:
                            if (board[row, column] is ' ')
                            {
                                board[row, column] = 'X'; // Fill the table if it is empty
                                move = true;
                            }
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            result = true;
                            break;
                    }
                }
        }
    }
}
