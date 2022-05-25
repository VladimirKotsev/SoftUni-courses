using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            char[] chars = text.ToCharArray();
            foreach (char c in chars)
            {
                if (!symbols.ContainsKey(c))                        symbols.Add(c, 1);
                else
                    symbols[c]++;
            }
            foreach (var sym in symbols)
                Console.WriteLine($"{sym.Key}: {sym.Value} time/s");
        }
    }
}
