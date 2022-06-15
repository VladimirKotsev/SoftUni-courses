using System;
using System.Collections.Generic;

namespace _05._Comparing_Objects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int countOfMatches = 0;
            int countOfNotEqualMatches = 0;

            string[] input = Console.ReadLine().Split(' ');
            while (input[0] != "END")
            {
                Person person = new Person(input[0], int.Parse(input[1]), input[2]);
                people.Add(person);
                input = Console.ReadLine().Split(' ');
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            for (int i = 0; i < people.Count; i++)
            {
                int result = people[index].CompareTo(people[i]);
                if (result == 0)
                {
                    countOfMatches++;
                }
                else if (result != 0)
                {
                    countOfNotEqualMatches++;
                }

            }
            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine($"{countOfMatches} {countOfNotEqualMatches} {people.Count}");
        }
    }
}
