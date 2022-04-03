using System;
using System.Text;

namespace _01_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stops = new StringBuilder();
            string plan = Console.ReadLine();
            stops.Append(plan);
            string command = Console.ReadLine();
            while (command != "Travel")
            {
                string[] cmd = command.Split(':');
                switch (cmd[0])
                {
                    case "Add Stop":
                        if (int.Parse(cmd[1]) >= 0 && int.Parse(cmd[1]) <= stops.Length - 1)
                        {
                            stops.Insert(int.Parse(cmd[1]), cmd[2]);
                        }
                        Console.WriteLine(stops.ToString());
                        break;

                    case "Remove Stop":
                        int length = int.Parse(cmd[2]) - int.Parse(cmd[1]);
                        if (int.Parse(cmd[1]) >= 0 && int.Parse(cmd[1]) <= stops.Length - 1 && int.Parse(cmd[2]) >= 0 && int.Parse(cmd[2]) <= stops.Length - 1)
                        {
                            stops.Remove(int.Parse(cmd[1]), length + 1);
                        }
                        Console.WriteLine(stops.ToString());
                        break;

                    case "Switch":
                        stops.Replace(cmd[1], cmd[2]);
                        Console.WriteLine(stops.ToString());
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops.ToString()}");
        }
    }
}
