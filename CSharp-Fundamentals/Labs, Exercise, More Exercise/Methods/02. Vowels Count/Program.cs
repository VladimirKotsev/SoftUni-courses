using System;
using System.Linq;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.ToLower();
            int count = 0;
            foreach(char c in input)
            {
                count += IsVowel(c);
            }
            Console.WriteLine(count);
        }
        static int IsVowel(char c)
        {
            int count = 0;
            switch (c)
            {
                case 'a': count++; break;
                case 'e': count++; break;
                case 'i': count++; break;
                case 'o': count++; break;
                case 'u': count++; break;
            }
            return count;
        }
    }
}
