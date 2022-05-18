using System;
using System.Collections.Generic;

namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                stack.Push(c);
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
