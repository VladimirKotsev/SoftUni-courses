using System;
using System.Collections.Generic;

namespace _06._Equality_Logic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var hashSet = new HashSet<Person>();
            var sortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                Person person = new Person(line[0], int.Parse(line[1]));
                hashSet.Add(person);
                sortedSet.Add(person);
            }
            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
