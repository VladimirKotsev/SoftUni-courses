using System;

namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputNumbersAndOperator();
        }
        static void InputNumbersAndOperator()
        {
            int number1 = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(number1, @operator, number2));
        }
        static int Calculate(int num1, char @operator, int num2)
        {
            int returnnValue = 0;
            switch(@operator)
            {
                case '/': returnnValue = num1 / num2; break;
                case '*': returnnValue = num1 * num2; break;
                case '+': returnnValue = num1 + num2; break;
                case '-': returnnValue = num1 - num2; break;
            }
            return returnnValue;
        }
    }
}
