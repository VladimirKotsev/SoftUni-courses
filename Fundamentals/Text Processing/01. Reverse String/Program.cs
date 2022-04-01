using System;

namespace _01._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string input = Console.ReadLine();
                string reversed = "";
                if (input == "end")
                {
                    break;
                }
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed += input[i];
                }
                Console.WriteLine($"{input} = {reversed}");
            }
        }
    }
}
