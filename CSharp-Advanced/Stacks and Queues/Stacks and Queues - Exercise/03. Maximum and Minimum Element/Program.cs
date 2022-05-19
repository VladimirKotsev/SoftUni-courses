using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ');
                switch (cmd[0])
                {
                    case "1": stack.Push(int.Parse(cmd[1])); 
                        break;
                    case "2": stack.Pop(); 
                        break;
                    case "3": 
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Max());
                        break;
                    case "4":
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Min()); 
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", stack));            
        }
    }
}
