using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> materials = new SortedDictionary<string, int>();
            Dictionary<string, int> trash = new Dictionary<string, int>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int i = 1; i < input.Length; i += 2)
                {
                    input[i] = input[i].ToLower();
                    if (input[i] == "shards" || input[i] == "motes" || input[i] == "fragments")
                    {
                        if (materials.ContainsKey(input[i]))
                        {
                            materials[input[i]] += int.Parse(input[i - 1]);
                        }
                        else
                        {
                            materials.Add(input[i], int.Parse(input[i - 1]));
                        }
                        if (CheckForObtaining(materials, trash))
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (trash.ContainsKey(input[i]))
                        {
                            trash[input[i]] += int.Parse(input[i - 1]);
                        }
                        else
                        {
                            trash.Add(input[i], int.Parse(input[i - 1]));
                        }
                    }
                }
            } // end while          
        }
        static bool CheckForObtaining(SortedDictionary<string, int> gold, Dictionary<string, int> trash)
        {
            if (gold.ContainsKey("shards"))
            {
                if (gold["shards"] >= 250)
                {
                    Console.WriteLine("Shadowmourne obtained!");
                    gold["shards"] -= 250;
                    PrintOutput(gold, trash);
                    return true;
                }
            }
            if (gold.ContainsKey("fragments"))
            {
                if (gold["fragments"] >= 250)
                {
                    Console.WriteLine("Valanyr obtained!");
                    gold["fragments"] -= 250;
                    PrintOutput(gold, trash);
                    return true;
                }
            }
            if (gold.ContainsKey("motes"))
            {
                if (gold["motes"] >= 250)
                {
                    Console.WriteLine("Dragonwrath obtained!");
                    gold["motes"] -= 250;
                    PrintOutput(gold, trash);
                    return true;
                }
            }
            return false;
        }
        static void PrintOutput(SortedDictionary<string, int> gold, Dictionary<string, int> trash)
        {
            if (!gold.ContainsKey("shards"))
            {
                gold.Add("shards", 0);
            }
            if (!gold.ContainsKey("motes"))
            {
                gold.Add("motes", 0);
            }
            if (!gold.ContainsKey("fragments"))
            {
                gold.Add("fragments", 0);
            }
            Console.WriteLine($"shards: {gold["shards"]}");
            Console.WriteLine($"motes: {gold["motes"]}");
            Console.WriteLine($"fragments: {gold["fragments"]}");
            foreach (var junk in trash)
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }
    }
}
