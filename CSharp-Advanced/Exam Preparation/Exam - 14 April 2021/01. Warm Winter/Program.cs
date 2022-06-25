using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sets = new List<int>();
            Stack<int> hats = StackUp();
            Queue<int> scarfs = QueueUp();

            while (true)
            {
                if (hats.Count == 0 || scarfs.Count == 0)
                    break;
                if (hats.Peek() > scarfs.Peek())
                {
                    sets.Add(hats.Peek() + scarfs.Peek());
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    int value = hats.Pop();
                    hats.Push(value + 1);
                    scarfs.Dequeue();
                }
                else if (scarfs.Peek() > hats.Peek())
                {
                    hats.Pop();
                    continue;
                }
            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(String.Join(' ', sets));
        }
        static Stack<int> StackUp()
        {
            Stack<int> hats = new Stack<int>();
            int[] hatsLine = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            foreach(int hat in hatsLine)
            {
                hats.Push(hat);
            }
            return hats;
        }
        static Queue<int> QueueUp()
        {
            Queue<int> scarfs = new Queue<int>();
            int[] scarfsLine = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            foreach(int scarf in scarfsLine)
            {
                scarfs.Enqueue(scarf);
            }
            return scarfs;
        }
        static void GetFewerLength(Stack<int> hats, Queue<int> scarfs)
        {
            int length = 0;
            if (hats.Count >= scarfs.Count)
                length = scarfs.Count;
            else
                length = hats.Count;
        }
    }
}
