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
                                        if (CheckWinCondition('X', board))
                                        {
                                            EndGame("\n" + player1.Prenom + " à gagné et marque 1 point!", board);
                                            player1.Score += 1;
                                            Console.WriteLine("\n" + player1.Prenom + ": " + player1.Score + " Poin(s)\n" + player2.Prenom + ": " + player2.Score + " Point(s)");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Player2Turn(result, board);
                                        if (CheckWinCondition('O', board))
                                        {
                                            EndGame("\n" + player2.Prenom + " à gagné et marque 1 point!", board);
                                            player2.Score += 1;
                                            Console.WriteLine("\n" + player1.Prenom + ": " + player1.Score + " Poin(s)\n" + player2.Prenom + ": " + player2.Score + " Point(s)");
                                            break;
                                        }
                                    }
                                    playerTurn = !playerTurn;
                                    if (CheckFullBoard(board))
                                    {
                                        EndGame("égalité", board);
                                        break;
                                    }
                                }

                            
                                if (!result)
                                {
                                    Console.WriteLine("\n Rejouer [enter], ou quitter [escape]?");
                                GetInput:
                                    switch (Console.ReadKey(true).Key)
                                    {
                                        case ConsoleKey.Enter: break;
                                        case ConsoleKey.Escape:
                                            result = true;
                                            Console.Clear();
                                            break;
                                        default: goto GetInput;
                                    }
                                }
                            }
        }

        private static bool CheckFullBoard(char[,] board)
        {
            if(
            board[0, 0] != ' ' && board[1, 0] != ' ' && board[2, 0] != ' ' &&
            board[0, 2] != ' ' && board[1, 2] != ' ' && board[2, 2] != ' ' &&
            board[0, 1] != ' ' && board[1, 1] != ' ' && board[2, 1] != ' ')
            {
                return true;
            } else {
                return false;
            }
        }

        
        private static void Player2Turn(bool result, char[,] board)
        {
            var (row, column) = (0, 0);
                bool move = false;
                while (!move && !result)
                {
                    Console.Clear();
                    Board(board);
                    Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow: row = row <= 0 ? 2 : row - 1; break;
                        case ConsoleKey.DownArrow: row = row >= 2 ? 0 : row + 1; break;
                        case ConsoleKey.LeftArrow: column = column <= 0 ? 2 : column - 1; break;
                        case ConsoleKey.RightArrow: column = column >= 2 ? 0 : column + 1; break;
                        case ConsoleKey.Enter:
                            if (board[row, column] is ' ')
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

        private static void EndGame(object value,char[,] board)
        {
            Console.Clear();
            Board(board);
            Console.WriteLine();
            Console.Write(value);
        }
        private static void Board(char[,] board)
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
        private static bool CheckWinCondition(char k, char[,] board)
        {
            if(
            board[0, 0] == k && board[1, 0] == k && board[2, 0] == k ||
            board[0, 1] == k && board[1, 1] == k && board[2, 1] == k ||
            board[0, 2] == k && board[1, 2] == k && board[2, 2] == k ||
            board[0, 0] == k && board[0, 1] == k && board[0, 2] == k ||
            board[1, 0] == k && board[1, 1] == k && board[1, 2] == k ||
            board[2, 0] == k && board[2, 1] == k && board[2, 2] == k ||
            board[0, 0] == k && board[1, 1] == k && board[2, 2] == k ||
            board[2, 0] == k && board[1, 1] == k && board[0, 2] == k)
            {
                return true;
            } else{
                return false;
            }
        }

        private static void Player1Turn(bool result, char[,] board)
        {
            var (row, column) = (0, 0);
                bool move = false;
                while (!move && !result)
                {
                    Console.Clear();
                    Board(board);

                    Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow: row = row <= 0 ? 2 : row - 1; break;
                        case ConsoleKey.DownArrow: row = row >= 2 ? 0 : row + 1; break;
                        case ConsoleKey.LeftArrow: column = column <= 0 ? 2 : column - 1; break;
                        case ConsoleKey.RightArrow: column = column >= 2 ? 0 : column + 1; break;
                        case ConsoleKey.Enter:
                            if (board[row, column] is ' ')
                            {
                                board[row, column] = 'X';
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
