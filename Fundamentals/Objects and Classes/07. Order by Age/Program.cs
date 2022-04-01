using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Identity
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public Identity(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Identity> people = new List<Identity>();
            List<string> IDs = new List<string>();
            while (input != "End")
            {
                string[] person = input.Split(" ");
                if (IDs.Contains(person[1]))
                {
                    int indexToChange = people.FindIndex(x => x.Name == person[0]);
                    people[indexToChange].Name = person[0];
                    people[indexToChange].Age = int.Parse(person[2]);
                }
                else
                {
                    Identity identity = new Identity(person[0], person[1], int.Parse(person[2]));
                    people.Add(identity);
                    IDs.Add(person[1]);
                    input = Console.ReadLine();
                }
            }
            PrintExit(people.OrderBy(x => x.Age).ToList());

        }
        static void PrintExit(List<Identity> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i].Name} with ID: {list[i].ID} is {list[i].Age} years old.");
            }
        }
    }
}
