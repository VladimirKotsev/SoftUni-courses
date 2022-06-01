using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int[] range = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int lowerBorder = range[0];
            int upperBorder = range[1];
            string condition = Console.ReadLine();
            // true -> even, false -> odd
            Predicate<int> filter = x => x % 2 == 0;
            for (int i = lowerBorder; i <= upperBorder; i++)
            {
                if (condition == "even" && filter(i))
                {
                    list.Add(i);
                }
                else if (condition == "odd" && !filter(i))
                {
                    list.Add(i);
                }
            }
            Console.WriteLine(String.Join(' ', list));
        }
    }
}
