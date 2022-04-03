using System;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]";
            Regex regex = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    char[] array = match.Groups[2].Value.ToCharArray();
                    Console.Write(match.Groups[1].ToString() + ": ");
                    foreach(char c in array)
                    {
                        Console.Write((int)c + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
