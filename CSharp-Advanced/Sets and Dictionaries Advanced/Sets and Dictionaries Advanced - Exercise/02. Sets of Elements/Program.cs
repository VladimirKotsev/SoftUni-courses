using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            string input = Console.ReadLine();
            int n = int.Parse(input.Split(' ')[0]);
            int m = int.Parse(input.Split(' ')[1]);
            for (int i = 0; i < n; i++)
                first.Add(int.Parse(Console.ReadLine()));
            for (int i = 0; i < m; i++)
                second.Add(int.Parse(Console.ReadLine()));
            first.IntersectWith(second);
            Console.WriteLine(String.Join(' ', first));
        }
    }
}
