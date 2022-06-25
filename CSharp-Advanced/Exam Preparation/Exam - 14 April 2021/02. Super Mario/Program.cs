using System;
using System.Linq;

namespace _02._Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] field = new char[n][];

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                field[row] = line.ToCharArray();
            }

            while (true)
            {
                char[] command = Console.ReadLine()
                    .Split(' ')
                    .Select(char.Parse)
                    .ToArray();

                char cmd = command[0];
                int spawnRow = int.Parse(command[1].ToString());
                int spawnCol = int.Parse(command[2].ToString());
                field[spawnRow][spawnCol] = 'B';
                int row = 0;
                int col = 0;

                (row, col) = FindMarioPlayer(field);
                bool alive = true;
                bool reachedPrincess = false;

                switch (cmd)
                {
                    case 'W': //up
                        if (ValidIndex(field, row - 1, col))
                        {
                            field[row][col] = '-';
                            (field, lives, alive, reachedPrincess) = SimulateMovement(field, lives, row - 1, col);
                            if (alive == false)
                            {
                                row--;
                                field[row][col] = 'X';
                            }
                            else
                            {
                                row--;
                                field[row][col] = 'M';
                            }
                        }

                        break;
                    case 'A': //left
                        if (ValidIndex(field, row, col - 1))
                        {
                            field[row][col] = '-';
                            (field, lives, alive, reachedPrincess) = SimulateMovement(field, lives, row, col - 1);
                            if (alive == false)
                            {
                                col--;
                                field[row][col] = 'X';
                            }
                            else
                            {
                                col--;
                                field[row][col] = 'M';
                            }
                        }
                        break;
                    case 'S': //down
                        if (ValidIndex(field, row + 1, col))
                        {
                            field[row][col] = '-';
                            (field, lives, alive, reachedPrincess) = SimulateMovement(field, lives, row + 1, col);
                            if (alive == false)
                            {
                                row++;
                                field[row][col] = 'X';
                            }
                            else
                            {
                                row++;
                                field[row][col] = 'M';
                            }
                        }
                        break;
                    case 'D':
                        if (ValidIndex(field, row, col + 1))
                        {
                            field[row][col] = '-';
                            (field, lives, alive, reachedPrincess) = SimulateMovement(field, lives, row, col + 1);
                            if (alive == false)
                            {
                                col++;
                                field[row][col] = 'X';
                            }
                            else
                            {
                                col++;
                                field[row][col] = 'M';
                            }
                        }
                        break;

                }
                if (alive == false)
                {
                    Console.WriteLine($"Mario died at {row};{col}.");
                    PrintOutField(field);
                    break;
                }
                else if (reachedPrincess == true)
                {
                    field[row][col] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! ");
                    Console.WriteLine($"Lives left: {lives}");
                    PrintOutField(field);
                    break;
                }
            }
        }
        static void PrintOutField(char[][] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                Console.WriteLine(String.Join(null ,field[row]));
            }
        }
        static (int, int) FindMarioPlayer(char[][] field)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'M')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return (row, col);
        }
        static bool ValidIndex(char[][] field, int row, int col)
        {
            if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field[row].Length)
            {
                return true;
            }
            return false;
        }
        static (char[][], int, bool, bool) SimulateMovement(char[][] field, int lives, int row, int col)
        {
            bool alive = true;
            bool reachedPrincess = false;
            if (field[row][col] == 'B')
            {
                lives -= 3;
                if (lives > 0)
                {
                    field[row][col] = 'M';
                }
                else
                {
                    alive = false;
                }
            }
            else if (field[row][col] == 'P')
            {
                lives--;
                field[row][col] = '-';
                reachedPrincess = true;
            }
            else if (field[row][col] == '-')
                lives--;
            return (field, lives, alive, reachedPrincess);
        }
    }
}
