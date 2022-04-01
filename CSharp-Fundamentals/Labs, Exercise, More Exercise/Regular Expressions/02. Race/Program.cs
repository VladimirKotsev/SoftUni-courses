using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder name = new StringBuilder();
            Dictionary<string, int> players = new Dictionary<string, int>();
            string pattern = @"(?<name>[A-Za-z])|(?<meters>[\d])";
            string[] names = Console.ReadLine().Split(", ");
            string input = Console.ReadLine();
            int km = 0;

            while (input != "end of race")
            {
                MatchCollection match = Regex.Matches(input, pattern);
                name.Clear();
                km = 0;
                foreach (Match m in match)
                {
                    string s = m.Value;
                    char[] c = s.ToCharArray();
                    if (Char.IsLetter(c[0]))
                    {
                        name.Append(c[0]);
                    }
                    else if (Char.IsDigit(c[0]))
                    {
                        km += c[0] - 48;
                    }

                }
                if (names.Contains(name.ToString()))
                {

                    if (players.ContainsKey(name.ToString()))
                    {
                        players[name.ToString()] += km;
                    }
                    else
                    {
                        players.Add(name.ToString(), km);
                    }

                }

                input = Console.ReadLine();
            }

            var sorted = players.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            string[] array =
            {
                "1st",
                "2nd",
                "3rd"
            };
            int j = 0;
            foreach (var play in sorted.Keys)
            {
                if (j > 2)
                {
                    return;
                }
                Console.WriteLine($"{array[j]} place: {play}");
                j++;
            }
        }
    }
}
