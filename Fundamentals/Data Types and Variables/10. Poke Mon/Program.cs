using System;

namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal N = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            decimal n = N;
            int pokeCounter = 0;
            while (n > m)
            {
                if (N / 2 == n)
                {
                    n = n / y;
                }
                n = n - m;
                pokeCounter++;
            }
            if (N / 2 == n)
            {
                n = (int)n / y;
            }
            Console.WriteLine(n);
            Console.WriteLine(pokeCounter);
        }
    }
}
