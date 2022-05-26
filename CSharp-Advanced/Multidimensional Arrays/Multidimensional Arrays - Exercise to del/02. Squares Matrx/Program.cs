using System;
using System.Linq;

namespace _02._Squares_Matrx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];
            for (int i = 0; i < dimensions[0]; i++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = currRow[j];
                }
            }
            for (int i = 0; i < dimensions[0] - 1; i++)
                for (int j = 0; j < dimensions[1] - 1; j++)
                {
                    int toMatch = matrix[i, j];
                    if (toMatch == matrix[i, j + 1] && toMatch == matrix[i + 1, j] && toMatch == matrix[i + 1, j + 1])
                        count++;
                }
            Console.WriteLine(count);
        }
    }
}
