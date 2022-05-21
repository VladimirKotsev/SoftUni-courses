using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];
            int[,] winner = new int[2, 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < currRow.Length; j++)
                {
                    matrix[i, j] = currRow[j];
                }
            }
            int sum = 0;
            int max = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int n1 = matrix[row, col];
                    int n2 = matrix[row, col + 1];
                    int n3 = matrix[row + 1, col];
                    int n4 = matrix[row + 1, col + 1];
                    sum = n1 + n2 + n3 + n4;
                    if (sum > max)
                    {
                        max = sum;
                        winner[0, 0] = n1;
                        winner[0, 1] = n2;
                        winner[1, 0] = n3;
                        winner[1, 1] = n4;
                    }
                }
            }
            for (int i = 0; i < winner.GetLength(0); i++)
            {
                for (int j = 0; j < winner.GetLength(1); j++)
                {
                    Console.Write($"{winner[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(max);
        }
    }
}
