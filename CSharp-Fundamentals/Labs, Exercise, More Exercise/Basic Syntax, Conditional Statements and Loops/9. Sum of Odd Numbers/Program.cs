using System;

namespace _9._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int number = 1;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(number);
                sum += number;
                number += 2;
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
