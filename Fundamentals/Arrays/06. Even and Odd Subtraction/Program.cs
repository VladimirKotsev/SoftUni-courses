using System;

namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rawArray = Console.ReadLine().Split();
            int sumOfEven = 0;
            int sumOfOdd = 0;
            for (int i = 0; i < rawArray.Length; i++)
            {
                int digit = int.Parse(rawArray[i]);
                if (digit % 2 ==0)
                {
                    sumOfEven += digit;
                }
                else
                {
                    sumOfOdd += digit;
                }
            }
            Console.WriteLine(sumOfEven - sumOfOdd);
        }
    }
}
