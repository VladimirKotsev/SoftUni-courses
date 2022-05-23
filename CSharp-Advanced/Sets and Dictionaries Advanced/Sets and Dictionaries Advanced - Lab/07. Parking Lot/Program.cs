using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmd = command.Split(", ");
                switch (cmd[0])
                {
                    case "IN": parkingLot.Add(cmd[1]); break;
                    case "OUT": parkingLot.Remove(cmd[1]); break;
                }
                command = Console.ReadLine();
            }
            if (parkingLot.Count > 0)
                foreach (var car in parkingLot)
                    Console.WriteLine(car);
            else
                Console.WriteLine("Parking Lot is Empty");
        }
    }
}
