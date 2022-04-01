using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            OutputText(product, quantity);
        }
        static void OutputText(string type, int quantity)
        {
            double price = PriceCalculation(type) * quantity;
            Console.WriteLine($"{price:f2}");
        }
        static double PriceCalculation(string type)
        {
            double price = 0;
            switch (type)
            {
                case "coffee": price = 1.50; break;
                case "water": price = 1.00; break;
                case "coke": price = 1.40; break;
                case "snacks": price = 2.00; break;
            }
            return price;
        }
    }
}
