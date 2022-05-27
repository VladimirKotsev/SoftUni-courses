using System;
using System.Linq;

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string d in input)
            {
                int[] dimensions = d.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = dimensions[0];
                int col = dimensions[1];
                if (matrix[row, col] > 0)
                    matrix = GetNewMatrix(matrix, row, col);
            }
            int sum = 0;
            int counter = 0;
            for (int row = 0; row < n; row++)
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        counter++;
                        sum += matrix[row, col];
                    }
                }
            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                    Console.Write(matrix[row, col] + " ");
                Console.WriteLine();
            }
        }
        static int[,] GetNewMatrix(int[,] copyMatrix, int row, int col)
        {
            int maxRow = copyMatrix.GetLength(0);
            int maxCol = maxRow;
            int power = copyMatrix[row, col];
            if (row - 1 >= 0) // first row
            {
                if (copyMatrix[row - 1, col] > 0) // above bomb
                    copyMatrix[row - 1, col] -= power;

                if (col - 1 >= 0) // first row
                    if (copyMatrix[row - 1, col - 1] > 0) // above and to the left of bomb
                        copyMatrix[row - 1, col - 1] -= power;
                if (col + 1 < maxCol) // first row
                    if (copyMatrix[row - 1, col + 1] > 0) // above and to the right of bomb
                        copyMatrix[row - 1, col + 1] -= power;
            }
            if (col - 1 >= 0) // second row
                if (copyMatrix[row, col - 1] > 0) // to the left of bomb
                    copyMatrix[row, col - 1] -= power;
            if (col + 1 < maxCol) // second row
                if (copyMatrix[row, col + 1] > 0) // to the right of bomb
                    copyMatrix[row, col + 1] -= power;
            if (row + 1 < maxRow) // third row
            {
                if (copyMatrix[row + 1, col] > 0) // below bomb
                    copyMatrix[row + 1, col] -= power;

                if (col + 1 < maxCol) // third row
                    if (copyMatrix[row + 1, col + 1] > 0) //below and to the right of bomb
                        copyMatrix[row + 1, col + 1] -= power;
                if (col - 1 >= 0) // third row
                    if (copyMatrix[row + 1, col - 1] > 0) // below and to the left of bomb
                        copyMatrix[row + 1, col - 1] -= power;
            }
            copyMatrix[row, col] = 0; //bomb -> dead
            return copyMatrix;
        }

    }
}
