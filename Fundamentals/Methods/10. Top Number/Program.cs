using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int topBorder = int.Parse(Console.ReadLine());
            PrintTopNumbers(topBorder);
        }
        static void PrintTopNumbers(int max)
        {
            for (int i = 1; i <= max; i++)
            {
                if (IsSumOfDigitsValid(i) && IsThereAOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool IsSumOfDigitsValid(int num)
        {
            string length = num.ToString();
            int sum = 0;
            for (int i = 1; i <= length.Length; i++)
            {
                int digit = num % 10;
                num = num / 10;
                sum += digit;
            }
            return sum % 8 == 0;
        }
        static bool IsThereAOddDigit(int num)
        {
            string length = num.ToString();
            int count = 0;
            for (int i = 1; i <= length.Length; i++)
            {
                int digit = num % 10;
                num = num / 10;
                if (digit % 2 != 0)
                {
                    count++;
                }
            }
            if (count >= 1)
            {
                return true;
            }
            return false;
        }
        
    }
}
