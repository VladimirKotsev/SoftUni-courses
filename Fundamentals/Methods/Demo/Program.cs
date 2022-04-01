using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] {1, 2, 3, 4, 5};
            Console.WriteLine(String.Join(" ", array));
            array = null;
            Console.WriteLine(String.Join(" ", array));
        }
    }
}
