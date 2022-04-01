using System;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] peopleOnWagon = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                peopleOnWagon[i] = int.Parse(Console.ReadLine());
                sum += peopleOnWagon[i];
            }
            Console.WriteLine(string.Join(" ", peopleOnWagon));
            Console.WriteLine(sum);
            //int n = int.Parse(Console.ReadLine());
            //int sum = 0;
            //for (int i = 1; i <= n; i++)
            //{
            //    int digit = int.Parse(Console.ReadLine());
            //    Console.Write($"{digit} ");
            //    sum += digit;
            //}
            //Console.WriteLine();
            //Console.WriteLine(sum);
        }
    }
}
