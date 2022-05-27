using System;
using System.Linq;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            string[] directions = Console.ReadLine().Split(' ');
            int coalCounter = 0;
            int currRow = 0;
            int currCol = 0;
            for (int row = 0; row < n; row++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = char.Parse(line[col]);
                    if (char.Parse(line[col]) == 'c')
                        coalCounter++;
                    else if (char.Parse(line[col]) == 's')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            foreach (string direction in directions)
            {
                switch (direction)
                {
                    case "up":
                        if (currRow - 1 >= 0)
                        {
                            currRow--;
                            if (field[currRow, currCol] == 'c')
                            {
                                coalCounter--;
                                field[currRow, currCol] = '*';
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            
                        }
                        break;
                    case "right":
                        if (currCol + 1 < n)
                        {
                            currCol++;
                            if (field[currRow, currCol] == 'c')
                            {
                                coalCounter--;
                                field[currRow, currCol] = '*';
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                        }
                        break;
                    case "left":
                        if (currCol - 1 >= 0)
                        {
                            currCol--;
                            if (field[currRow, currCol] == 'c')
                            {
                                coalCounter--;
                                field[currRow, currCol] = '*';
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                        }
                        break;
                    case "down":
                        if (currRow + 1 < n)
                        {
                            currRow++;
                            if (field[currRow, currCol] == 'c')
                            {
                                coalCounter--;
                                field[currRow, currCol] = '*';
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                        }
                        break;
                }
                if (coalCounter == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                    return;
                }
            }
            Console.WriteLine($"{coalCounter} coals left. ({currRow}, {currCol})");
        }
    }
}
