using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string student = line[0];
                decimal grade = decimal.Parse(line[1]);
                if (students.ContainsKey(student))
                    students[student].Add(grade);
                else
                    students.Add(student, new List<decimal>() { grade });
            }
            foreach (var st in students.Keys)
            {
                Console.Write($"{st} -> ");
                foreach (var gr in students[st])
                {
                    Console.Write($"{gr:0.00} ");
                }
                Console.Write($"(avg: {Math.Round(students[st].Average(), 2,MidpointRounding.AwayFromZero):0.00})");
                Console.WriteLine();
            }
        }
    }
}
