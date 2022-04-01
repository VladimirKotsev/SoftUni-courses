using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listToManipulate = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string inputCommand = Console.ReadLine();
            while (inputCommand != "end")
            {
                string[] array = inputCommand.Split(' ');
                string command = array[0];
                int n = int.Parse(array[1]);
                
                switch (command)
                {
                    case "Add": listToManipulate.Add(n); break;
                    case "Remove": listToManipulate.Remove(n); break;
                    case "RemoveAt": listToManipulate.RemoveAt(n); break;
                    case "Insert": int index = int.Parse(array[2]);
                        listToManipulate.Insert(index, n); break;
                }
                inputCommand = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", listToManipulate));
        }
    }
}
