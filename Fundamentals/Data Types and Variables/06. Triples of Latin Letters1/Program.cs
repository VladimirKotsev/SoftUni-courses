using System;

namespace _06._Triples_of_Latin_Letters1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char a = (char)96;
            char b = (char)96;
            char c = (char)96;
            for (int i = 1; i <= n; i++)
            {
                a += (char)1;
                for (int j = 1; j <= n; j++)
                {
                    b += (char)1;
                    for (int k = 1; k <= n; k++)
                    {
                        c += (char)1;
                        Console.WriteLine($"{a}{b}{c}");
                    }
                    c = (char)96;
                }
                b = (char)96;
            }
        }
    }
}
