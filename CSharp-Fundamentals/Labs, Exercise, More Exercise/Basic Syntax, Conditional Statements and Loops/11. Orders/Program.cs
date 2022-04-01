using System;

namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double amount = 0;
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                double price = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int count = int.Parse(Console.ReadLine());
                amount = ((days * count) * price);
                sum += amount;
                Console.WriteLine($"The price for the coffee is: ${amount:f2}");
            }
            Console.WriteLine($"Total: ${sum:f2}");
        }
    }
}
