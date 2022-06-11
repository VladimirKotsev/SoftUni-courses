using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ').ToList();
            string command = Console.ReadLine();
            var removed = new List<string>();

            while (command != "Print")
            {
                string[] cmd = command.Split(';');
                string condition = cmd[1];
                string parameter = cmd[2];
                if (cmd[0] == "Add filter")
                {
                    Predicate<string> filter = GetFilterRemove(condition, parameter);
                    removed.AddRange(people.Where(x => filter(x)));
                    people.RemoveAll(filter);

                }
                else if (cmd[0] == "Remove filter")
                {
                    Func<string, bool> filter = GetFilter(condition, parameter);

                    people.AddRange(removed.Where(filter));
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(' ', people));

        }
        static Predicate<string> GetFilterRemove(string condition, string parameter)
        {
            if (condition == "Starts with")
            {
                return x => x.StartsWith(parameter);
            }
            else if (condition == "Ends with")
            {
                return x => x.EndsWith(parameter);
            }
            else if (condition == "Length")
            {
                return x => x.Length == int.Parse(parameter);
            }
            else if (condition == "Contains")
            {
                return x => x.Contains(parameter);
            }
            throw new ArgumentException("Invalid command");
        }
        static Func<string, bool> GetFilter(string condition, string parameter)
        {
            if (condition == "Starts with")
            {
                return x => x.StartsWith(parameter);
            }
            else if (condition == "Ends with")
            {
                return x => x.EndsWith(parameter);
            }
            else if (condition == "Length")
            {
                return x => x.Length == int.Parse(parameter);
            }
            else if (condition == "Contains")
            {
                return x => x.Contains(parameter);
            }
            throw new ArgumentException("Invalid command");
        }
    }
}
