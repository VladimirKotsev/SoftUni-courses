using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int[] dimensions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            char[,] lair = new char[dimensions[0], dimensions[1]];
            int currRow = 0;
            int currCol = 0;
            for (int row = 0; row < dimensions[0]; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < dimensions[1]; col++)
                {
                    lair[row, col] = char.Parse(line[col].ToString());
                    if (line[col] == 'P')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            string directions = Console.ReadLine();
            foreach (char c in directions)
            {
                switch (c)
                {
                    case 'L':
                        if (currCol - 1 >= 0)
                        {
                            lair[currRow, currCol] = '.';
                            currCol--;
                            if (lair[currRow, currCol] == 'B')
                            {
                                Exit(lair, currRow, currCol, false);
                                return;
                            }
                            lair[currRow, currCol] = 'P';
                            list = Multiply(lair);
                            if (list[0] == "True")
                            {
                                PrintOut(lair, int.Parse(list[1]), int.Parse(list[2]), false);
                                return;
                            }
                        }
                        else
                        {
                            lair[currRow, currCol] = '.';
                            Exit(lair, currRow, currCol, true);
                            return;
                        }
                        break;
                    case 'R':
                        if (currCol + 1 < dimensions[1])
                        {
                            lair[currRow, currCol] = '.';
                            currCol++;
                            if (lair[currRow, currCol] == 'B')
                            {
                                Exit(lair, currRow, currCol, false);
                                return;
                            }
                            lair[currRow, currCol] = 'P';
                            list = Multiply(lair);
                            if (list[0] == "True")
                            {
                                PrintOut(lair, int.Parse(list[1]), int.Parse(list[2]), false);
                                return;
                            }
                        }
                        else
                        {
                            lair[currRow, currCol] = '.';
                            Exit(lair, currRow, currCol, true);
                            return;
                        }
                        break;
                    case 'U':
                        if (currRow - 1 >= 0)
                        {
                            lair[currRow, currCol] = '.';
                            currRow--;
                            if (lair[currRow, currCol] == 'B')
                            {
                                Exit(lair, currRow, currCol, false);
                                return;
                            }
                            lair[currRow, currCol] = 'P';
                            list = Multiply(lair);
                            if (list[0] == "True")
                            {
                                PrintOut(lair, int.Parse(list[1]), int.Parse(list[2]), false);
                                return;
                            }
                        }
                        else
                        {
                            lair[currRow, currCol] = '.';
                            Exit(lair, currRow, currCol, true);
                            return;
                        }
                        break;
                    case 'D':
                        if (currRow + 1 < dimensions[0])
                        {
                            lair[currRow, currCol] = '.';
                            currRow++;
                            if (lair[currRow, currCol] == 'B')
                            {
                                Exit(lair, currRow, currCol, false);
                                return;
                            }
                            lair[currRow, currCol] = 'P';
                            list = Multiply(lair);
                            if (list[0] == "True")
                            {
                                PrintOut(lair, int.Parse(list[1]), int.Parse(list[2]), false);
                                return;
                            }

                        }
                        else
                        {
                            lair[currRow, currCol] = '.';
                            Exit(lair, currRow, currCol, true);
                            return;
                        }
                        break;
                }
            }
        }
        static List<string> Multiply(char[,] lair)
        {
            int endRow = 0;
            int endCol = 0;
            bool dead = false;
            List<string> cordinates = BunniesMultiplier(lair);
            List<string> output = new List<string>()
            {
                null,
                null,
                null
            };
            for (int i = 0; i < cordinates.Count; i++)
            {
                int row = int.Parse(cordinates[i].Split(',')[0]);
                int col = int.Parse(cordinates[i].Split(',')[1]);
                if (row - 1 >= 0)
                {
                    if (lair[row - 1, col] == '.')
                        lair[row - 1, col] = 'B';
                    else if (lair[row - 1, col] == 'P')
                    {
                        lair[endRow, endCol] = 'B';
                        endRow = row - 1;
                        endCol = col;
                        dead = true;
                    }
                }
                if (col - 1 >= 0)
                {
                    if (lair[row, col - 1] == '.')
                        lair[row, col - 1] = 'B';
                    else if (lair[row, col - 1] == 'P')
                    {
                        lair[endRow, endCol] = 'B';
                        endRow = row;
                        endCol = col - 1;
                        dead = true;
                    }
                }
                if (row + 1 < lair.GetLength(0))
                {
                    if (lair[row + 1, col] == '.')
                        lair[row + 1, col] = 'B';
                    else if (lair[row + 1, col] == 'P')
                    {
                        lair[endRow, endCol] = 'B';
                        endRow = row + 1;
                        endCol = col;
                        dead = true;
                    }
                }
                if (col + 1 < lair.GetLength(1))
                {
                    if (lair[row, col + 1] == '.')
                        lair[row, col + 1] = 'B';
                    else if (lair[row, col + 1] == 'P')
                    {
                        lair[endRow, endCol] = 'B';
                        endRow = row;
                        endCol = col + 1;
                        dead = true;
                    }
                }
            }
            if (dead)
            {
                output.Clear();
                output.Add(dead.ToString());
                output.Add(endRow.ToString());
                output.Add(endCol.ToString());
            }
            return output;
        }
        static List<string> BunniesMultiplier(char[,] lair)
        {
            List<string> cordinates = new List<string>();
            for (int row = 0; row < lair.GetLength(0); row++)
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                        cordinates.Add(row.ToString() + ',' + col.ToString());
                }
            return cordinates;
        }
        static void PrintOut(char[,] matrix, int row, int col, bool fail)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            if (fail)
                Console.WriteLine($"won: {row} {col}");
            else
                Console.WriteLine($"dead: {row} {col}");
        }
        static void Exit(char[,] lair, int row, int col, bool fail)
        {
            Multiply(lair);
            PrintOut(lair, row, col, fail);
            return;
        }
    }
}
