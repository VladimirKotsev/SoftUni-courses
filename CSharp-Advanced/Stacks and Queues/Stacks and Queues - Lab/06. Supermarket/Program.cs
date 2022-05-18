using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> salaryQueue = new Queue<string>();
            string cmd = Console.ReadLine();
            while (cmd != "End")
            
            {
                if (cmd == "Paid")
                {
                    int count = salaryQueue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(salaryQueue.Dequeue());
                    }
                }
                else
                {
                    salaryQueue.Enqueue(cmd);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"{salaryQueue.Count} people remaining.");
        }
    }
}
