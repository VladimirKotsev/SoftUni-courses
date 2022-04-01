using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputForAll = Console.ReadLine()
                .Split(">>")
                .ToArray();
            decimal sum = 0;
            for (int i = 0; i < inputForAll.Length; i++)
            {
                List<string> eachVechicle = inputForAll[i].Split(' ').ToList();
                switch(eachVechicle[0])
                {
                    case "family": sum += FamilyCar(eachVechicle); break;
                    case "heavyDuty": sum += HeavyDutyCar(eachVechicle); break;
                    case "sports": sum += SportsCar(eachVechicle); break;
                    default: Console.WriteLine("Invalid car type."); break;
                }
            }
            Console.WriteLine($"The National Revenue Agency will collect {sum:f2} euros in taxes.");
        }
        static decimal FamilyCar(List<string> listForVechicle)
        {
            int years = int.Parse(listForVechicle[1]);
            int km = int.Parse(listForVechicle[2]);
            int @base = km / 3000 * 12;
            decimal total = @base + (50 - years * 5);
            Console.WriteLine($"A family car will pay {total:f2} euros in taxes.");
            return total;
        }
        static decimal HeavyDutyCar(List<string> listForVechicle)
        {
            int years = int.Parse(listForVechicle[1]);
            int km = int.Parse(listForVechicle[2]);
            int @base = km / 9000 * 14;
            decimal total = @base + (80 - years * 8);
            Console.WriteLine($"A heavyDuty car will pay {total:f2} euros in taxes.");
            return total;
        }
        static decimal SportsCar(List<string> listForVechicles)
        {
            int years = int.Parse(listForVechicles[1]);
            int km = int.Parse(listForVechicles[2]);
            int @base = km / 2000 * 18;
            decimal total = @base + (100 - years * 9);
            Console.WriteLine($"A sports car will pay {total:f2} euros in taxes.");
            return total;
        }
    }
}
