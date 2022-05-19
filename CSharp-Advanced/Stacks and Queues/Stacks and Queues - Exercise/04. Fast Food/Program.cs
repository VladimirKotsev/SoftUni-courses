using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> orders = new Queue<int>();
            int inStock = int.Parse(Console.ReadLine());
            int[] clients = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < clients.Length; i++)
                orders.Enqueue(clients[i]);
            Console.WriteLine(orders.Max());
            int count = orders.Count();
            for (int i = 1; i <= count; i++)
            {
                if (inStock >= orders.Peek())
                    inStock-= orders.Dequeue();
                else if (inStock < orders.Peek())
                {
                    Console.Write("Orders left: ");
                    while (orders.Count != 0)
                    {
                        Console.Write(orders.Dequeue() + " ");
                    }
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
