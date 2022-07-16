namespace _06._Food_Shortage
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (line.Length == 4)
                {
                    Citizen citizen = new Citizen(line[0], int.Parse(line[1]), line[2], line[3]);
                    citizens.Add(citizen);
                }
                else if (line.Length == 3)
                {
                    Rebel rebel = new Rebel(line[0], int.Parse(line[1]), line[2]);
                    rebels.Add(rebel);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                foreach (Citizen citizen in citizens)
                {
                    if (input == citizen.Name)
                    {
                        citizen.BuyFood();
                    }
                }
                foreach (Rebel rebel in rebels)
                {
                    if (input == rebel.Name)
                    {
                        rebel.BuyFood();
                    }
                }

                input = Console.ReadLine();
            }

            int sum = 0;
            foreach (var citizen in citizens)
                sum += citizen.Food;
            foreach (var rebel in rebels)
                sum += rebel.Food;
            Console.WriteLine(sum);
        }
    }
}
