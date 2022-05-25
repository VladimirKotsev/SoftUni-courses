using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                foreach (string el in line)
                    elements.Add(el);
            }
            Console.WriteLine(String.Join(' ', elements));    
        }
    }
}
