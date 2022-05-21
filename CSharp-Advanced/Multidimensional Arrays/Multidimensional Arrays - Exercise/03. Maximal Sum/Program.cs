using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];
            int[,] winnerMatrix = new int[3, 3];
            //fill matrix
            for (int row = 0; row < dimensions[0]; row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < dimensions[1]; col++)
                    matrix[row, col] = currRow[col]; 
            }
            //Max sum
            int max = 0;
            for (int row = 0; row < dimensions[0] - 2; row++)
                for(int col = 0; col < dimensions[1] - 2; col++)
                {
                    int n1 = matrix[row, col];
                    int n2 = matrix[row, col + 1];
                    int n3 = matrix[row, col + 2];
                    int n4 = matrix[row + 1, col];
                    int n5 = matrix[row + 1, col + 1];
                    int n6 = matrix[row + 1, col + 2];
                    int n7 = matrix[row + 2, col];
                    int n8 = matrix[row + 2, col + 1];
                    int n9 = matrix[row + 2, col + 2];
                    int sum = n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9;
                    if(sum > max)
                    {
                        max = sum;
                        winnerMatrix[0, 0] = n1;
                        winnerMatrix[0, 1] = n2;
                        winnerMatrix[0, 2] = n3;
                        winnerMatrix[1, 0] = n4;
                        winnerMatrix[1, 1] = n5;
                        winnerMatrix[1, 2] = n6;
                        winnerMatrix[2, 0] = n7;
                        winnerMatrix[2, 1] = n8;
                        winnerMatrix[2, 2] = n9;
                    }
                }
            //output
            Console.WriteLine($"Sum = {max}");
            for(int row = 0; row < 3; row++)
            {
                for(int col = 0; col < 3; col++)
                    Console.Write($"{winnerMatrix[row, col]} ");
                Console.WriteLine();
            }

        }
    }
}
