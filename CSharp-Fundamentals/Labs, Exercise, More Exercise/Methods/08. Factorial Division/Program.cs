using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"{FirstNumberFactorial(firstNumber) / SecondNumberFactorial(secondNumber):f2}");
        }
        static double FirstNumberFactorial(int firstNumber)
        {
            double sum = 1;
            for (int i = 1; i <= firstNumber; i++)
            {
                sum *= i;
            }
            return sum;
        }
        static double SecondNumberFactorial(int sectorNumber)
        {
            double sum = 1;
            for (int i = 1; i <= sectorNumber; i++)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
