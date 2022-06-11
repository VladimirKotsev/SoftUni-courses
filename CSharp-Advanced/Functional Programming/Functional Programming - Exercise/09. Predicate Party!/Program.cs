using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> invites = Console.ReadLine()
                .Split(' ')
                .ToList();
            Predicate<string> checkingCmd = (string cmd) => cmd == "Double";
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                //predicate - true -> cmd = Double; false -> cmd = Remove;
                string cmd = command.Split(' ')[0]; 
                string condition = command.Split(' ')[1];
                string parameter = command.Split(' ')[2];

                if (checkingCmd(cmd)) // Double
                {
                    Func<string, bool> filter = GetFilter(condition, parameter);
                    var filtered = invites.Where(filter).ToList();
                    invites.InsertRange(0, filtered);
                }
                else if (!checkingCmd(cmd)) // Remove
                {
                    Predicate<string> filter = GetPredicate(condition, parameter);
                    invites.RemoveAll(filter);
                }
                command = Console.ReadLine();
            }
            if (invites.Count > 0)
            {
                Console.Write(String.Join(", ", invites));
                Console.Write(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
        static Predicate<string> GetPredicate(string condition, string parameter)
        {
            Predicate<string> predicate = null;
            switch (condition)
            {
                case "StartsWith":
                    predicate = x => x.StartsWith(parameter);
                    break;
                case "EndsWith":
                    predicate = x => x.EndsWith(parameter);
                    break;
                case "Length":
                    predicate = x => x.Length == int.Parse(parameter);
                    break;
            }
            return predicate;
        }

        static Func<string, bool> GetFilter
            (string condition, string parameter)
        {
            Func<string, bool> predicate = null;
            switch(condition)
            {
                case "StartsWith":
                    predicate = x => x.StartsWith(parameter);
                    break;
                case "EndsWith":
                    predicate = x => x.EndsWith(parameter);
                    break;
                case "Length":
                    predicate= x => x.Length == int.Parse(parameter);
                    break;
            }
            return predicate;
        }
    }
}
