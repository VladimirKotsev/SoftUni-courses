using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            switch (type)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday": price = 8.45; break;
                        case "Saturday": price = 9.80; break;
                        case "Sunday": price = 10.46; break;
                    }
                    if (count >= 30)
                    {
                        price *= 0.85;
                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday": price = 10.90; break;
                        case "Saturday": price = 15.60; break;
                        case "Sunday": price = 16; break;
                    }
                    if (count >= 100)
                    {
                        count -= 10;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday": price = 15; break;
                        case "Saturday": price = 20; break;
                        case "Sunday": price = 22.50; break;
                    }
                    if (count >= 10 && count <= 20)
                    {
                        price *= 0.95;
                    }
                    break;
            }   
            Console.WriteLine($"Total price: {price * count:f2}");
        }
    }
}
