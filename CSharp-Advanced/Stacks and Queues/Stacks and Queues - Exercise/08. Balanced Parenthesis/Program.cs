using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length / 2; i++)
                stack1.Push(input[i]);
            for (int i = input.Length - 1; i >= input.Length / 2; i--)
                stack2.Push(input[i]);
            { }
            //bool answer = true;
            while(stack1.Count != 0)
            {
                if (stack2.Peek() - 1 == stack1.Peek() || stack2.Peek() - 2 == stack1.Peek())
                {
                    stack1.Pop();
                    stack2.Pop();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
            //for (int i = input.Length / 2 ; i < input.Length; i++)
            //{
            //    if (stack.Peek() == input[i] - 1 || stack.Peek() == input[i] - 2)
            //        answer = true;               
            //    else
            //    {
            //        answer = false;
            //        break;
            //    }

            //    stack.Pop();                  
            //}
            //if (answer)
            //    Console.WriteLine("YES");
            //else
            //    Console.WriteLine("NO");
            
        }
    }
}
