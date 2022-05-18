using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char c = char.Parse(input[i].ToString());
                if (c == '(')
                {
                    stack.Push(i);
                }
                else if (c == ')')
                {
                    int start = stack.Pop();
                    string bracket = input.ToString().Substring(start, i - start + 1);
                    Console.WriteLine(bracket);
                }
            }
        }
    }
}
