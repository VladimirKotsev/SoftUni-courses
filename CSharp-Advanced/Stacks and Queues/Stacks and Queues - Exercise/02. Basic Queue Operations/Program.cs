using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            (int enqueueCount, int dequeueCount, int toFind) = (input[0], input[1], input[2]);
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < enqueueCount; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < dequeueCount; i++)
            {
                queue.Dequeue();
            }
            int min = int.MaxValue;
            if (queue.Contains(toFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                while (queue.Count != 0)
                {
                    int dequeued = queue.Dequeue();
                    if (min > dequeued)
                    {
                        min = dequeued;
                    }
                }
                if (min == int.MaxValue)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(min);
                }
            }
            
        }
    }
}
