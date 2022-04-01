using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingLot = new Dictionary<string, string>();
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string command = input[0];
                string user = input[1];
                switch (command)
                {
                    case "register":
                        string licensePlate = input[2];
                        if (parkingLot.ContainsKey(user))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {parkingLot[user]}");
                        }
                        else
                        {
                            parkingLot.Add(user, licensePlate);
                            Console.WriteLine($"{user} registered {licensePlate} successfully");
                        }
                        break;
                    case "unregister":
                        if (!parkingLot.ContainsKey(user))
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                        }
                        else
                        {
                            parkingLot.Remove(user);
                            Console.WriteLine($"{user} unregistered successfully");
                        }
                        break;
                }
            }//end for cicle
            foreach (var p in parkingLot)
            {
                Console.WriteLine($"{p.Key} => {p.Value}");
            }
        }
    }
}
