using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int countOfShelfs = 1;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)  
                stack.Push(array[i]);
            while (stack.Count != 0)
            {
                if (sum + stack.Peek() > capacity)
                {
                    sum = stack.Pop();
                    countOfShelfs++;
                }
                else
                    sum += stack.Pop();
            }
            Console.WriteLine(countOfShelfs);
        }
    }
}
