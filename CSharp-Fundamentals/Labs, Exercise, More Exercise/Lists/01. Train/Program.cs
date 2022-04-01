using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagon = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string givenCommand = Console.ReadLine();
            while (givenCommand != "end")
            {
                string[] command = givenCommand.Split(" ");
                if (command[0] == "Add")
                {
                    wagon.Add(int.Parse(command[1]));
                }
                else
                {
                    int passengersToAdd = int.Parse(command[0]);
                    for (int i = 0; i < wagon.Count; i++)
                    {
                        if (wagon[i] + passengersToAdd <= maxCapacity)
                        {
                            wagon[i] += passengersToAdd;
                            break;
                        }
                        
                    }
                }

                givenCommand = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", wagon));
        }
    }
}
