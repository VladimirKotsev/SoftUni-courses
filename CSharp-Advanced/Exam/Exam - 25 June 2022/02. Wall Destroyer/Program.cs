using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = FillMatrix(n);

            string input = Console.ReadLine();
            int row = 0;
            int col = 0;
            (row, col) = FindVanko(wall);
            int holes = 1;
            int hitsOnSteel = 0;
            wall[row, col] = '*';
            bool alive = true;

            while (input != "End")
            {
                bool hitSteel = false;
                switch (input)
                {
                    case "up":
                        if (ValidateIndex(wall, row - 1, col))
                        {
                            wall[row, col] = '*';
                            row--;
                            (wall, row, col, holes, hitsOnSteel, alive, hitSteel) =
                                Movement(wall, row, col, holes, hitsOnSteel);
                            if (hitSteel == true)
                            {
                                row++;
                                wall[row, col] = 'V';
                            }
                        }

                        break;

                    case "down":
                        if (ValidateIndex(wall, row + 1, col))
                        {
                            wall[row, col] = '*';
                            row++;
                            (wall, row, col, holes, hitsOnSteel, alive, hitSteel) =
                                Movement(wall, row, col, holes, hitsOnSteel);
                            if (hitSteel == true)
                            {
                                row--;
                                wall[row, col] = 'V';
                            }
                        }

                        break;

                    case "left":
                        if (ValidateIndex(wall, row, col - 1))
                        {
                            wall[row, col] = '*';
                            col--;
                            (wall, row, col, holes, hitsOnSteel, alive, hitSteel) =
                                Movement(wall, row, col, holes, hitsOnSteel);
                            if (hitSteel == true)
                            {
                                col++;
                                wall[row, col] = 'V';
                            }
                        }

                        break;

                    case "right":
                        if (ValidateIndex(wall, row, col + 1))
                        {
                            wall[row, col] = '*';
                            col++;
                            (wall, row, col, holes, hitsOnSteel, alive, hitSteel) =
                                Movement(wall, row, col, holes, hitsOnSteel);
                            if (hitSteel == true)
                            {
                                col--;
                                wall[row, col] = 'V';
                            }
                        }
                        break;
                }
                if (alive == false)
                    break;


                input = Console.ReadLine();
            }
            if (alive == false)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                PrintMatrix(wall);
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {hitsOnSteel} rod(s).");
                PrintMatrix(wall);
            }

        }
        static char[,] FillMatrix(int n)
        {
            char[,] wall = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    wall[row, col] = (char)line[col];
                }
            }
            return wall;
        }
        static (int, int) FindVanko(char[,] wall)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < wall.GetLength(0); i++)
            {
                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    if (wall[i, j] == 'V')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return (row, col);
        }
        static bool ValidateIndex(char[,] wall, int row, int col)
        {
            if (row >= 0 && row < wall.GetLength(0) && col >= 0 && col < wall.GetLength(1))
            {
                return true;
            }
            return false;
        }
        static (char[,], int, int, int, int, bool, bool) Movement
            (char[,] wall, int row, int col, int holes, int hitsOnSteel)
        {
            bool alive = true;
            bool hitSteel = false;
            if (wall[row, col] == '-') // no hole there
            {
                holes++;
                wall[row, col] = 'V';
            }
            else if (wall[row, col] == '*') // already a hole there
            {
                wall[row, col] = 'V';
                Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
            }
            else if (wall[row, col] == 'R') // steel rod
            {
                hitSteel = true;
                hitsOnSteel++;
                Console.WriteLine("Vanko hit a rod!");
            }
            else if (wall[row, col] == 'C') // hit a cable
            {
                holes++;
                wall[row, col] = 'E';
                alive = false;
            }
            return (wall, row, col, holes, hitsOnSteel, alive, hitSteel);
        }
        static void PrintMatrix(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
