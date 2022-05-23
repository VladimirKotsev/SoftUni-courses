using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> openParentheses = new Stack<int>();
            Stack<int> closedParentheses = new Stack<int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length / 2; i++)
                openParentheses.Push(input[i]);
            for (int i = input.Length - 1; i >= input.Length / 2; i--)
                closedParentheses.Push(input[i]);
            { }
            while(openParentheses.Count != 0)
            {
                if (openParentheses.Peek() == 40 && closedParentheses.Peek() == 41)
                {
                    openParentheses.Pop();
                    closedParentheses.Pop();
                }
                else if (openParentheses.Peek() == 91 && closedParentheses.Peek() == 93)
                {
                    openParentheses.Pop();
                    closedParentheses.Pop();
                }
                else if (openParentheses.Peek() == 123 && closedParentheses.Peek() == 125)
                {
                    openParentheses.Pop();
                    closedParentheses.Pop();
                }
                else if (openParentheses.Peek() == 41 && closedParentheses.Peek() == 40)
                {
                    openParentheses.Pop();
                    closedParentheses.Pop();
                }
                else if (openParentheses.Peek() == 93 && closedParentheses.Peek() == 91)
                {
                    openParentheses.Pop();
                    closedParentheses.Pop();
                }
                else if (openParentheses.Peek() == 125 && closedParentheses.Peek() == 123)
                {
                    openParentheses.Pop();
                    closedParentheses.Pop();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
