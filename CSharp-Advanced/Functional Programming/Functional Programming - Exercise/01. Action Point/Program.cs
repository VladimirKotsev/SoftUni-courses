using System;

namespace _01._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);
            string input = Console.ReadLine();
            string[] input2 = input.Split(' ');
            Array.ForEach(input2, print);
        }
    }
}
