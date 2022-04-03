using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _02_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\=)([A-Z][A-Za-z]{2,})(\=)|(\/)([A-Z][A-Za-z]{2,})(\/)";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            List<string> l = new List<string>();
            MatchCollection match = regex.Matches(input);
            int sum = 0;
            foreach (Match m in match)
            {
                if (m.Groups[2].Value == string.Empty)
                {
                    l.Add(m.Groups[5].Value);
                    sum += m.Groups[5].Value.Length;
                }
                else
                {
                    l.Add(m.Groups[2].Value);
                    sum += m.Groups[2].Value.Length;
                }
            }
            Console.WriteLine($"Destinations: " + String.Join(", ", l));
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}
