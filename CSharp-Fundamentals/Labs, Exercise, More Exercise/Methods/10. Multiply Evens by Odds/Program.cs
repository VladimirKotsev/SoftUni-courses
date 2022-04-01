using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            Console.WriteLine(GetMultipleOfEvenAndOdds(number));
        }
        static int GetSumOfEvenDigits(int num)
        {
            int sum = 0;
            sum += num;
            return sum;
        }
        static int GetSumOfOddDigits(int num)
        {
            int sum = 0;
            sum += num;
            return sum;
        }
        static int GetMultipleOfEvenAndOdds(int num)
        {
            string num1 = num.ToString();
            int sumOfEven = 0;
            int sumOfOdd = 0;
            for (int i = 1; i <= num1.Length; i++)
            {
                int digit = num % 10;
                num = num / 10;
                if (digit % 2 == 0)
                {
                    sumOfEven += GetSumOfEvenDigits(digit);
                }
                else
                {
                    sumOfOdd += GetSumOfOddDigits(digit);
                }
            }
            return sumOfOdd * sumOfEven;
        }
    }
}
