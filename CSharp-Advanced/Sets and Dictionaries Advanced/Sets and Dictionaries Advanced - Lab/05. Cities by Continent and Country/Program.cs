using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> world = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string continent = line[0];
                string country = line[1];
                string city = line[2];
                if (world.ContainsKey(continent))
                {
                    if (world[continent].ContainsKey(country))
                        world[continent][country].Add(city);
                    else
                        world[continent].Add(country, new List<string>() { city });
                }
                else
                {
                    world.Add(continent, new Dictionary<string, List<string>>());
                    world[continent].Add(country, new List<string>() { city });
                }
            }
            //Print out
            foreach(var c in world.Keys)
            {
                Console.WriteLine($"{c}:");
                foreach (var c2 in world[c])
                {
                    Console.WriteLine($"{c2.Key} -> {String.Join(", ", c2.Value)}");
                }
            }
        }
    }
}
