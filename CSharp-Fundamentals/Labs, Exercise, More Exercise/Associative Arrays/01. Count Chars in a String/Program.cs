using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Dictionary<char, int> counts = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char[] c = input[i].ToArray();
                for (int j = 0; j < c.Length; j++)
                {
                    if (counts.ContainsKey(c[j]))
                    {
                        counts[c[j]]++;
                    }
                    else
                    {
                        counts.Add(c[j], 1);
                    }
                }
            }
            foreach(var c in counts)
            {
                Console.WriteLine($"{c.Key} -> {c.Value}");
            }
        }
    }
}
