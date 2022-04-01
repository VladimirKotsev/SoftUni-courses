using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            string pattern = @">>(?<product>[\w]+)<<(?<price>\d+.(\d+)?)!(?<quantity>\d+)";
            List<string> items = new List<string>();
            double cost = 0;
            string input = Console.ReadLine();
            //while
            while (input != "Purchase")
            {
                Match matches = Regex.Match(input, pattern);
                if (matches.Success)
                {
                    items.Add(matches.Groups["product"].ToString());
                    double price = double.Parse(matches.Groups["price"].ToString());
                    int quantity = int.Parse(matches.Groups["quantity"].ToString());
                    cost += price * quantity;
                }

                input = Console.ReadLine();
            }
            //end while
            Console.WriteLine("Bought furniture:");
            //print
            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine($"Total money spend: {cost:f2}");
        }
    }
}
