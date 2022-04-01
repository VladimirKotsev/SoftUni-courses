using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            string manipulation = Console.ReadLine();
            while (manipulation != "end")
            {
                string[] command = manipulation.Split();
                if (command[0] == "Delete")
                {
                    int number = int.Parse(command[1]);
                    for(int i = 0; i < list.Count; i++)
                    {
                        if(list[i] == number)
                        {
                            list.RemoveAt(i);
                        }
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    int number = int.Parse(command[1]);
                    list.Insert(index, number);
                }
                manipulation = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
