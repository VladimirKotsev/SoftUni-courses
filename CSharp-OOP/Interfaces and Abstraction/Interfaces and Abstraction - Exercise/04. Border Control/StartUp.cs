namespace _04._Border_Control
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
                if (input.Length == 3)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    list.Add(input[2]);
                }
                else if (input.Length == 2)
                {
                    Robot robot = new Robot(input[0], input[1]);
                    list.Add(input[1]);
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string fakeId = Console.ReadLine();
            List<string> fakeIds = list.FindAll(x => x.EndsWith(fakeId));
            foreach (string id in fakeIds)
            {
                Console.WriteLine(id);
            }
        }
    }
}
