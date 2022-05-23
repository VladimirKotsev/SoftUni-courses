using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Prodict_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] cmd = command.Split(", ");
                string shop = cmd[0];
                string product = cmd[1];
                double price = double.Parse(cmd[2]);
                if (shops.ContainsKey(shop))
                {
                    if (shops[shop].ContainsKey(product))
                        shops[shop][product] = price;
                    else
                        shops[shop].Add(product, price);
                }
                else
                {
                    shops.Add(shop, new Dictionary<string, double>());
                    shops[shop].Add(product, price);
                }
                command = Console.ReadLine();
            }
            //output
            foreach (var store in shops.Keys)
            {
                Console.WriteLine($"{store}->");
                foreach (var p in shops[store])
                {
                    Console.WriteLine($"Product: {p.Key}, Price: {p.Value}");
                }
            }
        }
    }
}
