using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintNxNMatrix();
        }
        static int InputMethod()
        {
            return int.Parse(Console.ReadLine());
        }
        static void PrintNxNMatrix()
        {
            int count = InputMethod();
            for (int row = 1; row <= count; row++)
            {
                for (int col = 1; col <= count; col++)
                {
                    Console.Write(count + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
