using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string num = number.ToString();
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int digit = num[i];
                digit -= 48;
                if (digit == 0)
                {
                    digit = 1;
                }
                for (int j = digit -1;j >= 1; j--)
                {
                    digit *= j;
                }
                sum += digit;   
            }
            if (sum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
