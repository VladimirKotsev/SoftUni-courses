using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printAction = x => Console.WriteLine("Sir " + x);
            string[] input = Console.ReadLine().Split(' ');
            Array.ForEach(input, printAction);
        }
    }
}
