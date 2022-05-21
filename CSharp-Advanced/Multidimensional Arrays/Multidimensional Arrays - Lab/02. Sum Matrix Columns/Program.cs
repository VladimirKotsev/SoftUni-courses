using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
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
            for(int i = 0; i < dimensions[0]; i++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < currRow.Length; j++)
                {
                    matrix[i, j] = currRow[j];
                }
            }
            for (int i = 0; i < dimensions[1]; i++)
            {
                int sum = 0;
                for (int j = 0; j < dimensions[0]; j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
