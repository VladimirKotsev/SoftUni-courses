using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToArray();
            Console.WriteLine(String.Join(' ', line));

        }
    }
}
