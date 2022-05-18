using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            Queue<int> finalQueue = new Queue<int>();
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach (int i in array)
                queue.Enqueue(i);
            int count = queue.Count;
            for(int i = 0; i < count; i++)
            {
                if (queue.Peek() % 2 == 0)
                {
                    finalQueue.Enqueue(queue.Peek());
                }
                queue.Dequeue();
            }
            Console.WriteLine(String.Join(", ", finalQueue));
        }
    }
}
