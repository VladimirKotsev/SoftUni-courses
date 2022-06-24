using System;
using System.Linq;

namespace _02._Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] beach = new char[n][];

            for (int i = 0; i < n; i++)
            {
                beach[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            int tokenCollected = 0;
            int tokenOpponent = 0;
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "Gong")
            {
                string cmd = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                if (cmd == "Find")
                {
                    if (Validate(beach, row, col))
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            tokenCollected++;
                        }
                    }
                }
                else if (cmd == "Opponent")
                {
                    string direction = input[3];
                    if (Validate(beach, row, col))
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            tokenOpponent++;
                        }
                        tokenOpponent += OpponentCrapWalking(beach, row, col, direction);
                    }
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            } //while cycle

            PrintMatrix(beach);
            Console.WriteLine($"Collected tokens: {tokenCollected}");
            Console.WriteLine($"Opponent's tokens: {tokenOpponent}");


        }
        static bool Validate(char[][] beach, int row, int col)
        {
            bool valid = false;
            if (row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].Length)
            {
                valid = true;
            }
            return valid;
        }
        static int OpponentCrapWalking(char[][] beach, int row, int col, string direction)
        {
            int tokens = 0;
            if (direction == "up")
            {
                int counter = 0;
                row--;
                while (counter <= 2)
                {
                    if (Validate(beach, row, col))
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            tokens++;
                        }
                    }
                    row--;
                    counter++;
                }
            }
            else if (direction == "down")
            {
                int counter = 0;
                row++;
                while (counter <= 2)
                {
                    if (Validate(beach, row, col))
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            tokens++;
                        }
                    }
                    row++;
                    counter++;
                }
            }
            else if (direction == "left")
            {
                int counter = 0;
                col--;
                while (counter <= 2)
                {
                    if (Validate(beach, row, col))
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            tokens++;
                        }
                    }
                    col--;
                    counter++;
                }
            }
            else if (direction == "right")
            {
                int counter = 0;
                col++;
                while (counter <= 2)
                {
                    if (Validate(beach, row, col))
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            tokens++;
                        }
                    }
                    col++;
                    counter++;
                }
            }
            return tokens;
        }
        static void PrintMatrix(char[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                Console.WriteLine(String.Join(' ', beach[row]));
            }
        }
    }
}
