using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int j = 0;
            double moneyAvalible = double.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            double priceLS = double.Parse(Console.ReadLine());
            double priceRs = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());
            for (int i = 1; i <= count; i++)
            {
                if (i % 6 == 0)
                {
                    j++;
                }
            }
            double price = priceLS * (Math.Ceiling(count * 1.10)) + priceRs * count + priceBelt * (count - j);
            if (price <= moneyAvalible)
            {
                Console.WriteLine($"The money is enough - it would cost {price:f2}lv.");
            }
            else if (price > moneyAvalible)
            {
                price = price - moneyAvalible;
                Console.WriteLine($"John will need {price:f2}lv more.");
            }

        }
    }
}
