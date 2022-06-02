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
            string command = Console.ReadLine();
            Predicate<string> checkingCmd = (string cmd) => cmd == "Double";
            while (command != "Party!")
            {
                //predicate - true -> cmd = Double; false -> cmd = Remove;
                string cmd = command.Split(' ')[0]; 
                string condition = command.Split(' ')[1];
                string parameter = command.Split(' ')[2];

                if (checkingCmd(cmd)) // Double
                {

                }
                else if (!checkingCmd(cmd)) // Remove
                {

                }

            }

        }
        static Func<List<string>, string, string, List<string>> DealingWithCommand
            (List<string> list ,string condition, string parameter)
        {
            if (condition == "StartsWith")
                return (List<string> list, string con, string para) =>
                list.RemoveAll(x => x.StartsWith(parameter)).ToList();
        }
    }
}
