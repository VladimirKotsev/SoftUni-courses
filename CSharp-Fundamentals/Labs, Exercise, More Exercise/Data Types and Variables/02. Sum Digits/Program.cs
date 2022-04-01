using System;

namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n1 = Console.ReadLine();
            int n = int.Parse(n1);
            int sum = 0;
            for (int i = 1;i <= n1.Length; i++)
            {
                sum += n % 10;
                n /= 10;

            }
            Console.WriteLine(sum);
        }
    }
}
