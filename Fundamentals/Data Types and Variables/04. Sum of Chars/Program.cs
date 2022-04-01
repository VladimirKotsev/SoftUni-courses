using System;

namespace _04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1;i <= n; i++)
            {
                char a = char.Parse(Console.ReadLine());
                sum += a;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
