using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < currRow.Length; j++)
                    matrix[i, j] = currRow[j];
            }
            //Main diagonal
            int mainDiagonalSum = 0;
            for (int i = 0; i < n; i++)
                mainDiagonalSum += matrix[i, i];
            //Opposite diagonal
            int oppositeDiagonalSum = 0;
            int col = 0;
            for (int row = n - 1; row >= 0; row--)
            {
                oppositeDiagonalSum += matrix[row, col];
                col++;
            }
            int diff = mainDiagonalSum - oppositeDiagonalSum;
            if (diff < 0)
            {
                diff = -diff;
            }
            Console.WriteLine(diff);
        }
    }
}
