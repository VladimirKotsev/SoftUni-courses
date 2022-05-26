using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> openParentheses = new Stack<char>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                    openParentheses.Push(input[i]);
                else if (input[i] == ')' || input[i] == '}' || input[i] == ']')
                {
                    if (openParentheses.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else if (openParentheses.Peek() == '{' && input[i] == '}')
                    {
                        openParentheses.Pop();
                    }
                    else if (openParentheses.Peek() == '[' && input[i] == ']')
                    {
                        openParentheses.Pop();
                    }
                    else if (openParentheses.Peek() == '(' && input[i] == ')')
                    {
                        openParentheses.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
