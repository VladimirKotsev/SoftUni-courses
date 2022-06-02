using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int endBorder = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            bool status = true;
            Func<int, int, bool> predicate = (int i, int d) => i % d == 0;
            for (int i = 1; i <= endBorder; i++)
            {
                status = true;
                foreach (int d in dividers)
                {
                    if (!predicate(i, d))
                    {
                        status = false;
                        break;
                    }
                }
                if (status)
                    list.Add(i);
            }
            Console.WriteLine(String.Join(' ', list));
        }
    }
}
