using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string method = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            switch(method)
            {
                case "add": ToAdd(firstNumber, secondNumber); break;
                case "multiply": ToMultiply(firstNumber, secondNumber); break;
                case "subtract": ToSubtract(firstNumber, secondNumber); break;
                case "divide": ToDivide(firstNumber, secondNumber); break;
            }
        }
        static void ToAdd(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }
        static void ToMultiply(int num1, int num2)
        {
            Console.WriteLine(num1 * num2);
        }
        static void ToSubtract(int num1, int num2)
        {
            Console.WriteLine(num1 - num2);
        }
        static void ToDivide(int num1, int num2)
        {
            Console.WriteLine(num1 / num2);
        }
    }
}
