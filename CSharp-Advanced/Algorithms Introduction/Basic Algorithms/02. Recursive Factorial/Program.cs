using System;

namespace _02._Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long sum = GetRecursiveFactorial(n);
            Console.WriteLine(sum);
        }

        static long GetRecursiveFactorial(int n)
        {
            if (n - 1 == 0)
            {
                return 1;
            }
            return n * GetRecursiveFactorial(n - 1);
        }
    }
}
