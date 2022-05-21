using System;
using System.Collections.Generic;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] pascal = new long[rows][];
            //creating empty pascal
            for (int row = 0; row < rows; row++)
                pascal[row] = new long[row + 1];
            //main diagonal
            for (int i = 1; i < rows; i++)
                pascal[i][i] = 1;
            //col 0
            for (int i = 0; i < rows; i++)
                pascal[i][0] = 1;
            //filling inside triangle & printing
            if (rows == 1)
            {
                Console.WriteLine("1");
            }
            else
            {
                Console.WriteLine("1");
                Console.WriteLine("1 1");
            }
            for (int row = 2; row < rows; row++)
            {
                for (int col = 1; col <= row - 1; col++)
                {
                    pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                }
                Console.WriteLine(String.Join(' ', pascal[row]));
            }
        }
    }
}
