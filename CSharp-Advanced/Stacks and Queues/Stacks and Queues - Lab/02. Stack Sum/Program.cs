using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                stack.Push(array[i]);
            }
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] cmd = command.Split(' ');
                switch (cmd[0])
                {
                    case "add": 
                        stack.Push(int.Parse(cmd[1]));
                        stack.Push(int.Parse(cmd[2]));
                        break;
                    case "remove": int count = int.Parse(cmd[1]);
                        if (count <= stack.Count)
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
                command = Console.ReadLine().ToLower();
            }
            //int sum = 0;
            //for (int i = 0; i <= stack.Count + 1; i++)
            //{
            //    sum += stack.Pop();
            //}
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
