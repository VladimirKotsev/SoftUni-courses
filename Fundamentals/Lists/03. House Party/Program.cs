using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                string[] entry = Console.ReadLine().Split(" ");
                if (entry[2] == "going!")
                {
                    if (guestList.Contains(entry[0]))
                    {
                        Console.WriteLine($"{entry[0]} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(entry[0]);
                    }
                }
                else
                {
                    if (guestList.Contains(entry[0]))
                    {
                        guestList.Remove(entry[0]);
                    }
                    else if (!guestList.Contains(entry[0]))
                    {
                        Console.WriteLine($"{entry[0]} is not in the list!");
                    }
                }
            }
            Console.WriteLine(String.Join("\x0D", guestList));
        }
    }
}
