using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdnumber = int.Parse(Console.ReadLine());
            Console.WriteLine(SubtractMethod(SumOfFirstAndSecond(firstNumber, secondNumber), thirdnumber));
        }
        static int SumOfFirstAndSecond(int first, int second)
        {
            return first + second;
        }
        static int SubtractMethod(int sum, int number)
        {
            return sum - number;
        }
    }
}
