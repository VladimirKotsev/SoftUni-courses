using System;
using System.Collections.Generic;

namespace _03._Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" | ");
            Dictionary<string, List<string>> noteBook = new Dictionary<string, List<string>>();
            foreach (string s in input)
            {
                string[] s1 = s.Split(": ");
                if (noteBook.ContainsKey(s1[0]))
                {
                    noteBook[s1[0]].Add(s1[1]);
                }
                else
                {
                    noteBook.Add(s1[0], new List<string>() { s1[1] });
                }
            }
            string[] exam = Console.ReadLine().Split(" | ");
            string typeOfExam = Console.ReadLine();
            switch (typeOfExam)
            {
                case "Test":
                    foreach (string s in exam)
                    {
                        if (noteBook.ContainsKey(s))
                        {
                            Console.WriteLine($"{s}:");
                            foreach (var l in noteBook[s])
                            {
                                Console.WriteLine($" -{l}");
                            }
                        }
                    }
                    break;

                case "Hand Over":
                    Console.WriteLine(String.Join(" ", noteBook.Keys));
                    break;
            }
        }
    }
}
