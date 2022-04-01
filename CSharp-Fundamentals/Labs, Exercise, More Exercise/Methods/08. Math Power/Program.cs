using System;

namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int @base = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(MathPower(@base, power));
        }
        static int MathPower(int @base, int power)
        {
            int result = 1;
            for (int i = 1; i <= power; i++)
            {
                result *= @base;
            }
            return result;
        }
    }
}
