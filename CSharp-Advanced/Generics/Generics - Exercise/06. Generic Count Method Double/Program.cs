using System;
using System.Collections.Generic;

namespace _06._Generic_Count_Method_Double
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());
            var count = box.CountOFGreaterElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
