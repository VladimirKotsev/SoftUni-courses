using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            PrintAllCharacters(first, second);
        }
        static void PrintAllCharacters(char start, char end)
        {
            if (start > end)
            {
                char start1 = start;
                start = end;
                end = start1;
            }
            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
