using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(" -> ");
                string color = line[0];
                string[] clothes = line[1].Split(',');
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var clo in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clo))
                        wardrobe[color].Add(clo, 1);
                    else
                        wardrobe[color][clo]++;
                }
            }
            string[] toFind = Console.ReadLine().Split(' ');
            foreach (var category in wardrobe)
            {
                Console.WriteLine($"{category.Key} clothes:");
                foreach (var cl in wardrobe[category.Key])
                {
                    if (category.Key == toFind[0] && cl.Key == toFind[1])
                    {
                        Console.WriteLine($"* {cl.Key} - {cl.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {cl.Key} - {cl.Value}");
                }
            }

        }
    }
}
