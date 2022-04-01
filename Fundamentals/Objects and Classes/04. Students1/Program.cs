using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students1
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] array = Console.ReadLine().Split(' ');
                Student myStudent = new Student(array[0], array[1], double.Parse(array[2]));
                studentsList.Add(myStudent);
            }
            //studentsList.OrderByDescending(t => t.Grade).ThenBy(x => x.FirstName).ToList();
            List<Student> sortedStudents = studentsList.OrderByDescending(t => t.Grade).ThenBy(t => t.FirstName).ThenBy(t => t.LastName).ToList();
            for (int i = 0; i < studentsList.Count; i++)
            {
                Console.WriteLine($"{studentsList[i].FirstName} {studentsList[i].LastName}: {studentsList[i].Grade:f2}");
            }
        }
    }
}
