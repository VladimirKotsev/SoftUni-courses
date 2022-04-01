using System;
using System.Numerics;

namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int day = 0;
            int sumForWorkers = 0;
            long sumYield = 0;
            while (yield >= 100)
            {
                day++;
                sumYield += (long)yield;
                yield -= 10;
                sumForWorkers += 26;
            }
            sumForWorkers += 26;
            Console.WriteLine(day);
            Console.WriteLine(sumYield - (long)sumForWorkers);
        }
    }
}
