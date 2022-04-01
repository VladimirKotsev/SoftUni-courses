using System;

namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            Random random = new Random();
            for (int i = 0; i <= words.Length - 1; i++)
            {
                Console.WriteLine(words[random.Next(1, words.Length)]);
            }
        }
    }
}
