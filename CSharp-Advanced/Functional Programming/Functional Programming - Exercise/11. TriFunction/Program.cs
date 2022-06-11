using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine(names
                .FirstOrDefault(x => x.ToCharArray()
                    .Select(y => (int)y)
                    .Sum() >= number));
        }
    }
}
