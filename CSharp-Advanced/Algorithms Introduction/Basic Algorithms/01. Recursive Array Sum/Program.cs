using System;
using System.Linq;

namespace Basic_Algorithms___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            long sum = GetRecursiveSum(array, 0);
            Console.WriteLine(sum);
        }
        static long GetRecursiveSum(int[] array, int startIndex)
        {
            if (startIndex == array.Length - 1)
            {
                return array[startIndex];
            }
            return array[startIndex] + GetRecursiveSum(array, startIndex + 1);
        }
    }
}

