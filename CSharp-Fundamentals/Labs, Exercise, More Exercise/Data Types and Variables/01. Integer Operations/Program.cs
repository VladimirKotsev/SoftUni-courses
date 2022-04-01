using System;

namespace _01._Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstN = int.Parse(Console.ReadLine());
            int secondN = int.Parse(Console.ReadLine());
            int thirdN = int.Parse(Console.ReadLine());
            int forthN = int.Parse(Console.ReadLine());

            long sum = (long)firstN + (long)secondN;
            long devide = sum / (long)thirdN;
            long multiply = (long)devide * forthN;
            Console.WriteLine(multiply);
        }
    }
}
