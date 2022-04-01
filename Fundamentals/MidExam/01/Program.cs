using System;

namespace _01_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal pricePackOfFlour = decimal.Parse(Console.ReadLine());
            decimal priceForAnEgg = decimal.Parse(Console.ReadLine());
            decimal priceForApron = decimal.Parse(Console.ReadLine());
            decimal total = FlourMethod(students, pricePackOfFlour) + ApronMethod(students, priceForApron) + ((students * 10)*priceForAnEgg);
            if (total > budget)
            {
                Console.WriteLine($"{total - budget:f2}$ more needed.");
            }
            else if (total <= budget)
            {
                Console.WriteLine($"Items purchased for {total:f2}$.");
            }
        }
        static decimal FlourMethod(int students, decimal priceFlour)
        {
            int off = students / 5;
            students -= off;
            decimal totalPrice = priceFlour * students;
            return totalPrice;
        }
        static decimal ApronMethod(int students, decimal priceApron)
        {
            double count = Math.Ceiling(students * 1.20);
            return (decimal)count * priceApron;
        }
    }
}
