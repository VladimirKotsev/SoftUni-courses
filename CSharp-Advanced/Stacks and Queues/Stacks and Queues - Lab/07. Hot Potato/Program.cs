using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> circle = new Queue<string>();
            string[] children = Console.ReadLine().Split(' ');
            int hot = int.Parse(Console.ReadLine());
            for (int i = 0; i < children.Length; i++)
            {
                circle.Enqueue(children[i]);
            }
            while (circle.Count != 1)
            {
                for (int i = 1; i < hot; i++)
                {
                    string child = circle.Dequeue();
                    circle.Enqueue(child);
                }
                Console.WriteLine($"Removed {circle.Dequeue()}");
            }
            Console.WriteLine($"Last is {circle.Peek()}");
        }
    }
}
