using System;

namespace _05._Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rawArray = Console.ReadLine().Split();
            int sum = 0;
            for (int i = 0; i < rawArray.Length; i++)
            {
                int digit = int.Parse(rawArray[i]);
                if (digit % 2 ==0)
                {
                    sum += digit;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
