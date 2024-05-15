using System;

namespace GalodaVelha
{
    class Program
    {
        static char[,] board = new char[8, 8];
        static char[] players = { 'X', 'O' };
        static int turn = 0;

        static void Main(string[] args)
        {
            InitializeBoard();
            bool victory = false;
            bool draw = false;

            while (!victory && !draw)
            {
                PrintBoard();
                Console.WriteLine($"Player {players[turn]}, it's your turn.");
                int row, col;
                while (true)
                {
                    Console.Write("Enter row (0-7): ");
                    row = int.Parse(Console.ReadLine());
                    Console.Write("Enter column (0-7): ");
                    col = int.Parse(Console.ReadLine());

                    if (IsValidMove(row, col))
                    {
                        board[row, col] = players[turn];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can't make that move. Try another one.");
                    }
                }

                victory = CheckWin(players[turn]);
                draw = CheckDraw();

                if (victory)
                {
                    PrintBoard();
                    Console.WriteLine($"Player {players[turn]} is the winner!");
                }
                else if (draw)
                {
                    PrintBoard();
                    Console.WriteLine("It's a draw, nobody wins. Better luck next time!");
                }
                else
                {
                    turn = (turn + 1) % 2;
                }
            }
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i][j] = '.';
                }
            }
        }

        static void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool ValidMove(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8 && board[row, col] == '.';
        }

        static bool CheckWin(char player)
        {
            // Ver se as linhas alinham
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j <= 8 - 4; j++)
                {
                    if (board[i, j] == player && board[i, j + 1] == player && board[i, j + 2] == player && board[i, j + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Ver se as colunas alinham
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i <= 8 - 4; i++)
                {
                    if (board[i, j] == player && board[i + 1, j] == player && board[i + 2, j] == player && board[i + 3, j] == player)
                    {
                        return true;
                    }
                }
            }

            // Ver se as diagonais alinham (Esquerda mais a cima para direita mais a baixo)
            for (int i = 0; i <= 8 - 4; i++)
            {
                for (int j = 0; j <= 8 - 4; j++)
                {
                    if (board[i, j] == player && board[i + 1, j + 1] == player && board[i + 2, j + 2] == player && board[i + 3, j + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Ver se as diagonais alinham (Esquerda mais a baixo para direita mais a cima)
            for (int i = 3; i < 8; i++)
            {
                for (int j = 0; j <= 8 - 4; j++)
                {
                    if (board[i, j] == player && board[i - 1, j + 1] == player && board[i - 2, j + 2] == player && board[i - 3, j + 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CheckDraw()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}