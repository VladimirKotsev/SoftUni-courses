using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            List<string> input = Console.ReadLine().Split(' ').ToArray().ToList();
            input.Reverse();
            for (int i = 0; i < input.Count; i++)
            {
                stack.Push(input[i]);
            }
            int count = stack.Count - 1;
            int sum = 0;
            sum += int.Parse(stack.Pop());
            for (int i = 0; i < count / 2; i++)
            {
                char c = char.Parse(stack.Pop());
                switch (c)
                {
                    case '+':
                        sum += int.Parse(stack.Pop());
                        break;
                    case '-':
                        sum -= int.Parse(stack.Pop());
                        break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
