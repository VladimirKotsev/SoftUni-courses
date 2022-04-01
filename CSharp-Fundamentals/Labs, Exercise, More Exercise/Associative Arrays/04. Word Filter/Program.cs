using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length % 2 == 0 )
                {
                    dict.Add(input[i], input[i].Length);
                }
            }
            foreach(string key in dict.Keys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
