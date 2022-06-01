using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Filter_By_Age
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person (string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> listOfPeople = new List<Person> ();
            //Read people
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                listOfPeople = ReadPeople(listOfPeople);
            }

            //Get people
            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            Func<Person, bool> getByCondition = CreateFilter(condition, ageCondition);

            List<Person> match = listOfPeople.Where(getByCondition).ToList();

            //Print out
            string format = Console.ReadLine();
            Action<Person> createFilter = ActionMethod(format);
            PrintOut(match, createFilter);
        }
        static List<Person> ReadPeople(List<Person> list)
        {
            string[] people = Console.ReadLine().Split(", ");
            list.Add(new Person(people[0], int.Parse(people[1])));
            return list;
        }
        static Action<Person> ActionMethod(string format)
        {
            if (format == "name age")
                return (Person p) => Console.WriteLine($"{p.Name} - {p.Age}");
            else if (format == "age")
                return (Person p) => Console.WriteLine($"{p.Age}");
            else if (format == "name")
                return (Person p) => Console.WriteLine($"{p.Name}");
            throw new ArgumentException("Invalid");
        }
        static void PrintOut(List<Person> people, Action<Person> print)
        {
            foreach (var person in people)
                print(person);
        }
        static Func<Person, bool> CreateFilter(string condition, int age)
        {
            if (condition == "older")
                return x => x.Age >= age;
            if (condition == "younger")
                return x => x.Age < age;
            throw new ArgumentException("Invalid format");
        }
    }
}
