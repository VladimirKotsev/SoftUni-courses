using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string cmd = Console.ReadLine();
            int count = 0;
            Queue<string> queue = new Queue<string>();
            while (cmd != "end")
            {
                if (cmd == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    queue.Enqueue(cmd);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
