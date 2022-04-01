using System;
using System.Text;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(input);

            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '>')
                {
                    int power = sb[i + 1] - 48;
                    int index = i + 1;
                    while (power > 0)
                    {
                        if (sb.Length < index + 1)
                        {
                            PrintOut(sb);
                            return;
                        }
                        if (sb[index] == '>')
                        {
                            power += sb[index + 1] - 48;
                            index++;
                        }
                        sb.Remove(index, 1);
                        power--;

                        //index++;
                    }
                    i = index - 1;
                }
            }
            PrintOut(sb);
        }
        static void PrintOut(StringBuilder sb)
        {
            Console.WriteLine(sb.ToString());
        }
    }
}
