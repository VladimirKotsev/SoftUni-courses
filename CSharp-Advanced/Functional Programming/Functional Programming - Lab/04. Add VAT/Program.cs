using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVat = x => x *= 1.20m;
            decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(addVat)
                .ToArray();
            Array.ForEach(numbers, x => Console.WriteLine("{0:f2}", x));
        }
    }
}
