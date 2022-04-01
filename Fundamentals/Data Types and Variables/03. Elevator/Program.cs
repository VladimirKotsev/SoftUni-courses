using System;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double fullCourses = (double)people / capacity;
            fullCourses = Math.Ceiling(fullCourses);
            Console.WriteLine(fullCourses);
        }
    }
}
