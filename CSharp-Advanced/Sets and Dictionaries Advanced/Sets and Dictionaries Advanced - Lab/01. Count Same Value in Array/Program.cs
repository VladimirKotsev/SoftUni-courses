using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Value_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> counter = new Dictionary<double, int>();
            double[] line = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            foreach (var n in line)
            {
                if (counter.ContainsKey(n))
                    counter[n]++;
                else
                    counter.Add(n, 1);
            }
            //print out
            foreach (var number in counter)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
