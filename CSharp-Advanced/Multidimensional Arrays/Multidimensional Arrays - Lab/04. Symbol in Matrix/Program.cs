using System;

namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string fill = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = fill[j];
                }
            }
            char find = char.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == find)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            Console.WriteLine($"{find} does not occur in the matrix");
        }
    }
}
