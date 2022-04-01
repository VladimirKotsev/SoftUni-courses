using System;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' '); 
            Console.WriteLine(Formula(input[0], input[1]));
        }
        static int Formula(string first, string second)
        {
            int sum = 0;
            if (first.Length == second.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    char c1 = first[i];
                    char c2 = second[i];
                    sum += c1 * c2;
                }
            }
            else
            {
                if (first.Length > second.Length)
                {
                    int j = 0;
                    for (int i = 0; i < second.Length; i++)
                    {
                        char c1 = first[i];
                        char c2 = second[i];
                        sum += c1 * c2;
                        j = i;
                    }
                    for (int i = j + 1; i < first.Length; i++)
                    {
                        char c = first[i];
                        sum += c;
                    }
                }
                else
                {
                    int j = 0;
                    for (int i = 0; i < first.Length; i++)
                    {
                        char c1 = first[i];
                        char c2 = second[i];
                        sum += c1 * c2;
                        j = i;
                    }
                    for (int i = j + 1; i < second.Length; i++)
                    {
                        char c = second[i];
                        sum += c;
                    }
                }
            }
            return sum;
        }
    }
}
