using System;

namespace _05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine());
            string n = Console.ReadLine();
            for (int j = 1; j <= i; j++)
            {
                int actualN = int.Parse(n);
                if (actualN > 0)
                {
                    int maiNum = actualN % 10;
                    int offset = (maiNum - 2) * 3;
                    if (maiNum == 8 || maiNum == 9)
                    {
                        offset++;
                    }
                    int lIndex = offset + n.Length - 1;
                    lIndex += 97;
                    char index = (char)lIndex;
                    Console.Write(index);
                }
                else
                {
                    Console.Write(" ");
                }
                n = Console.ReadLine();
            }
        }
    }
}
