using System;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSmallestInteger();
        }
        static void PrintSmallestInteger()
        {
            int min = 2147483647;
            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < min)
                {
                    min = number;
                }
            }
            Console.WriteLine(min);
        }
    }
}
