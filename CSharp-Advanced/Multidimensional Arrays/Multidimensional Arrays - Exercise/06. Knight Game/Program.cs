using System;
using System.Linq;

namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            //fill matrix
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for(int col = 0; col < n; col++)
                {
                    field[row, col] = char.Parse(line[col].ToString());
                }
            }
            //body
            int removeCounter = 0;
            int rowKnight = 0;
            int colKnight = 0;
            int maxAttacks = 0;
            while (true)
            {
                maxAttacks = 0;
                for (int row = 0; row < n; row++)
                {
                    if (maxAttacks == 8)
                        break;
                    for (int col = 0; col < n; col++)
                    {
                        if (field[row, col] == 'K')
                        {
                            int attacks = GetAttacks(field, row, col);
                            if (attacks > maxAttacks)
                            {
                                maxAttacks = attacks;
                                rowKnight = row;
                                colKnight = col;
                                if (maxAttacks == 8)
                                    break;
                            }
                        }
                    }

                } //end of for body
                if (maxAttacks > 0)
                {
                    removeCounter++;
                    field[rowKnight, colKnight] = '0';
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removeCounter);
        }
        static int GetAttacks(char[,] field, int row, int col)
        {
            int attacks = 0;
            int maxRow = field.GetLength(0) - 1;
            int maxCol = field.GetLength(1) - 1;
            if (row - 2 >= 0 && col - 1 >= 0) // upper left
            {
                if (field[row - 2, col - 1] == 'K')
                    attacks++;
            }
            if (row - 2 >= 0 && col + 1 <= maxCol) // upper right
            {
                if (field[row - 2, col + 1] == 'K')
                    attacks++;
            }
            if (row - 1 >= 0 && col + 2 <= maxCol)//right upper
            {
                if (field[row - 1, col + 2] == 'K')
                    attacks++;
            } 
            if (row + 1 <= maxRow && col + 2 <= maxCol)// right lower
            {
                if(field[row + 1, col + 2] == 'K')
                    attacks++;
            }
            if (row + 2 <= maxRow && col + 1 <= maxCol)// lower right
            {
                if (field[row + 2, col + 1] == 'K')
                    attacks++;
            }
            if (row + 2 <= maxRow && col - 1 >= 0)//lower left
            {
                if (field[row + 2, col - 1] == 'K')
                    attacks++;
            }
            if (row + 1 <= maxRow && col - 2 >= 0)// lower left
            {
                if (field[row + 1, col - 2] == 'K')
                    attacks++;
            }
            if (row - 1 >= 0 && col - 2 >= 0)// upper left
            {
                if (field[row - 1, col - 2] == 'K')
                    attacks++;
            }
            return attacks;
        }
    }
}
