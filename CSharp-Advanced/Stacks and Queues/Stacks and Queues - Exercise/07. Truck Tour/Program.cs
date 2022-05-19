using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Pump
    {
        public int Number { get; set; }
        public int Quantity { get; set; }
        public int Distance { get; set; }

        public Pump(int number, int quantity, int distance)
        {
            this.Number = number;
            this.Quantity = quantity;
            this.Distance = distance;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<Pump> pumpQueue = new Queue<Pump>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] pump = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                Pump myPump = new Pump(i, pump[1], pump[2]);
                pumpQueue.Enqueue(myPump);
            }
        }
    }
}
