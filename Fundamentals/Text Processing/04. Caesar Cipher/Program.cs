using System;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CaesarCipher(input);
        }
        static void CaesarCipher(string input)
        {
            char[] c = input.ToCharArray();
            foreach (char letter in c)
            {
                int toPrint = letter + 3;
                Console.Write((char)toPrint);
            }
        }
    }
}
