using System;

namespace _01._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int max = -1000000;
            //int min = 1000000;
            //int middle = 0;
            //for (int i = 1; i <= 3; i++)
            //{
            //    int number = int.Parse(Console.ReadLine());
            //    if (number != max && number != min)
            //    {
            //        middle = number;
            //    }
            //    if (number < min)
            //    {
            //        min = number;
            //    }
            //    else if (number > max)
            //    {
            //        max = number;
            //    }
            //}
            int min = 0;
            int max = 0;
            int middle = 0;
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            if (num1 > num2 && num1 > num3)
            {
                max = num1;
            }
            else if (num2 > num1 && num2 > num3)
            {
                max = num2;
            }
            else if (num3 > num1 && num3 > num2)
            {
                max = num3;
            }
            if (num1 < num2 && num1 < num3)
            {
                min = num1;
            }
            else if (num2 < num1 && num2 < num3)
            {
                min = num2;
            }
            else if (num3 < num1 && num3 < num2)
            {
                min = num3;
            }
            if (num1 > min && num1 < max)
            {
                middle = num1;
            }
            else if (num2 > min && num2 < max)
            {
                middle = num2;
            }
            else if (num3 > min && num3 < max)
            {
                middle = num3;
            }
            Console.WriteLine(max);
            Console.WriteLine(middle);
            Console.WriteLine(min);
        }
    }
}
