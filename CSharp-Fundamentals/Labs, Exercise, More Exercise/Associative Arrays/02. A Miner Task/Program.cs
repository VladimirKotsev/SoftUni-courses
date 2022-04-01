using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> listOfResources = new Dictionary<string, int>();
            while(input != "stop")
            {
                string resource = input;
                int quantity = int.Parse(Console.ReadLine());
                if (listOfResources.ContainsKey(resource))
                {
                    listOfResources[resource] += quantity;
                }
                else
                {
                    listOfResources.Add(resource, quantity);
                }
                input= Console.ReadLine();
            }
            foreach(var h in listOfResources)
            {
                Console.WriteLine($"{h.Key} -> {h.Value}");
            }
        }
    }
}
