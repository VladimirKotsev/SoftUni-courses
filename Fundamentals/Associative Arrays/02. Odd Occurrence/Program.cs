using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Odd_Occurrence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(' ');
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach(string word in array)
            {
                string toLower = word.ToLower();
                if (counts.ContainsKey(toLower))
                {
                    counts[toLower]++;
                }
                else
                {
                    counts.Add(toLower, 1);
                }
            }
            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}
