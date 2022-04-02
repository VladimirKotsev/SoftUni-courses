using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sumLeft = 0;
            int sumRight = 0;
            sbyte index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i - 1; k >= 0; k--)
                {
                    sumLeft += array[k];
                }
                for (int j = i+1; j < array.Length; j++)
                {
                    sumRight += array[j];
                }
                if (sumLeft == sumRight)
                {
                    index = (sbyte)i;
                    Console.WriteLine(index);
                    return;
                }
                sumRight = 0;
                sumLeft = 0;
            }
            Console.WriteLine("no");
        }
    }
}
