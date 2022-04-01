using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            while (n % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                n = int.Parse(Console.ReadLine());
            }
            if (n > 0)
            {
                Console.WriteLine($"The number is: {n}");
            }
            else
            {
                Console.WriteLine($"The number is: {-n}");
            }
        }
    }
}
