using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int length = input.Length;
            PrintCharacters(input, length);
        }
        static bool CheckIfEven(int length)
        {
            if (length % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void PrintCharacters(string theString, int length)
        {
            char[] array = theString.ToCharArray();
            if (CheckIfEven(length))
            {
                Console.Write(array[array.Length / 2 - 1]);
                Console.Write(array[array.Length / 2]);
            }
            else
            {
                Console.WriteLine(array[array.Length / 2]);
            }
        }
    }
}
