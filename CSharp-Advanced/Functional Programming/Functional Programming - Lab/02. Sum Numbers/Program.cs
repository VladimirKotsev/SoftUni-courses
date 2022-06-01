using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int count = numbers.Length;
            int sum = numbers.Sum();
            Console.WriteLine(count);
            Console.WriteLine(sum);

        }
    }
}
