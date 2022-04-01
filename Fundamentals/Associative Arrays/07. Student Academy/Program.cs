using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Student_Academy
{
    class Student
    {
        public List<double> Grade { get; set; }
        public Student(double grade)
        {
            this.Grade = new List<double>();
            this.Grade.Add(grade);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                Student newStudent = new Student(grade);
                if (students.ContainsKey(name))
                {
                    students[name].Grade.Add(grade);
                }
                else
                {
                    students.Add(name, newStudent);
                }
            }
            foreach(var a in students)
            {
                double sum = a.Value.Grade.Sum();
                double average = sum / a.Value.Grade.Count;
                if (average >= 4.50)
                {
                    Console.WriteLine($"{a.Key} -> {average:f2}");
                }
            }
        }
    }
}
