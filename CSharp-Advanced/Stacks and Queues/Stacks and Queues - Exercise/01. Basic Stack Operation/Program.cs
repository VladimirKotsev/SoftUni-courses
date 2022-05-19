using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Basic_Stack_Operation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            (int pushCount, int popCount, int toFind) = (input[0], input[1], input[2]);
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < pushCount; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 1; i <= popCount; i++)
            {
                stack.Pop();
            }
            int min = int.MaxValue;
            if (stack.Contains(toFind))
            {
                Console.WriteLine("true");
                return;
            }
            else
            {
                while (stack.Count != 0)
                {
                    int poped = stack.Pop();
                    if (min > poped)
                    {
                        min = poped;
                    }
                }
                if (min != int.MaxValue)
                {
                    Console.WriteLine(min);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
