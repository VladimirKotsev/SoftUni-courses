using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Func<int[], int[]> reversAnArray = x => x.Reverse().ToArray();
            array = reversAnArray(array);
            int n = int.Parse(Console.ReadLine());
            //true -> remove; false -> stay;
            Predicate<int> predicate = PredicateMethod(n);
            var filtered = new List<int>();
            foreach (var arr in array)
            {
                if (!predicate(arr))
                    filtered.Add(arr);
            }
            Console.WriteLine(String.Join(' ', filtered));
        }
        static Predicate<int> PredicateMethod(int n)
        {
            return x => x % n == 0;
        }
    }
}
