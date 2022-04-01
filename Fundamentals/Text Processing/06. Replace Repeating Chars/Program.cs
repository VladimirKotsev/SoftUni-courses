using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toConvert = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < toConvert.Length - 1; i++)
            {
                if (toConvert[i] != toConvert[i + 1])
                {
                    sb.Append(toConvert[i]);
                }
            }
            sb.Append(toConvert[toConvert.Length - 1]);
            Console.WriteLine(sb.ToString());
        }
    }
}
