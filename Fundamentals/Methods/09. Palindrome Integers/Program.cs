using System;
using System.Linq;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                Console.WriteLine(IsPalindrom(input));
                input = Console.ReadLine();
            }
        }
        static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static bool IsPalindrom(string s)
        {
            if (s == ReverseString(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
