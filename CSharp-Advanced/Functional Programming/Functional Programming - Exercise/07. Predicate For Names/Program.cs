using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Func<string, bool> lengthFilter = FilterFunc(n);
            string[] input = Console.ReadLine()
                .Split(' ')
                .Where(lengthFilter)
                .ToArray();
            Array.ForEach(input, x => Console.WriteLine(x));
        }
        static Func<string, bool> FilterFunc(int n)
        {
            return x => x.Length <= n;
        }
    }
}
