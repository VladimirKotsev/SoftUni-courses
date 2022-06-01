using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> predicate = x => x.Length > 0 && Char.IsUpper(x[0]);
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(predicate)
                .ToArray();
            Array.ForEach(input, x => Console.WriteLine(x));

        }
    }
}
