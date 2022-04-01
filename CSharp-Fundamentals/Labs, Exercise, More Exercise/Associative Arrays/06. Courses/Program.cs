using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Courses
{
    class Student
    {
        public List<string> StudentName { get; set; }
        public int Count { get; set; }
        public Student(string student)
        {
            this.StudentName = new List<string>();
            this.StudentName.Add(student);
            this.Count = 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> courses = new Dictionary<string, Student>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] array = input.Split(" : ");
                string course = array[0];
                string student = array[1];
                Student myStudent = new Student(student);
                if (courses.ContainsKey(course))
                {
                    courses[course].StudentName.Add(student);
                    courses[course].Count++;
                }
                else if (!courses.ContainsKey(course))
                {
                    courses.Add(course, myStudent);

                }
                input = Console.ReadLine();
            }// end while
            foreach (var student in courses)
            {
                Console.WriteLine($"{student.Key}: {student.Value.Count}");
                foreach (var a in student.Value.StudentName)
                {
                    Console.WriteLine($"-- {a}");
                }
            }
        }
    }
}
