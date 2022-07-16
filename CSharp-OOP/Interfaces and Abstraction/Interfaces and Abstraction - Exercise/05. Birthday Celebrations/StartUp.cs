namespace _05._Birthday_Celebrations
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "End")
            {
                if (input[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    list.Add(input[4]);
                }
                else if (input[0] == "Robot")
                {
                    Robot robot = new Robot(input[0], input[1]);
                }
                else if (input[0] == "Pet")
                {
                    Pet pet = new Pet(input[1], input[2]);
                    list.Add(input[2]);
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string year = Console.ReadLine();
            List<string> dates = list.FindAll(x => x.EndsWith(year));
            foreach (string date in dates)
            {
                Console.WriteLine(date);
            }
        }
    }
}
