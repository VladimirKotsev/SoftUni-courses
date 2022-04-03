using System;
using System.Collections.Generic;

namespace _03_
{
    class PlantInfo
    {
        public double Rating { get; set; }
        public int Rarity { get; set; }
        public int Count { get; set; }
        public PlantInfo(int rarity)
        {
            this.Rarity = rarity;
            this.Rating = 0;
            this.Count = 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, PlantInfo> flowerBook = new Dictionary<string, PlantInfo>();
            for(int i = 0; i < n; i++)
            {
                string[] s = Console.ReadLine().Split("<->");
                PlantInfo newPlant = new PlantInfo(int.Parse(s[1]));
                flowerBook.Add(s[0], newPlant);
            }
            string command = Console.ReadLine();
            while (command != "Exhibition")
            {
                string[] cmd = command.Split(' ');
                string plant = cmd[1]; 
                switch (cmd[0])
                {
                    case "Rate:": 
                        if (flowerBook.ContainsKey(plant))
                        {
                            flowerBook[plant].Rating += double.Parse(cmd[3]);
                            flowerBook[plant].Count++;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update:":
                        if (flowerBook.ContainsKey(plant))
                        {
                            flowerBook[plant].Rarity = int.Parse(cmd[3]);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset:": 
                        if (flowerBook.ContainsKey(plant))
                        {
                            flowerBook[plant].Rating = 0;
                            flowerBook[plant].Count = 0;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var jmu in flowerBook)
            {
                if (jmu.Value.Rating > 0)
                {
                    Console.WriteLine($"- {jmu.Key}; Rarity: {jmu.Value.Rarity}; Rating: {jmu.Value.Rating / jmu.Value.Count:f2}");
                }
                else
                {
                    Console.WriteLine($"- {jmu.Key}; Rarity: {jmu.Value.Rarity}; Rating: {0:f2}");
                }
            }
        }
    }
}
