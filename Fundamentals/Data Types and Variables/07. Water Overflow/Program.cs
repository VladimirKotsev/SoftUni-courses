using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;
            int sum = 0;
            for (int i = 1; i<= n; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                sum += liters;
                if (sum > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    sum -= liters;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
