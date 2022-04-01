using System;
using System.Text;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringToRepeat = Console.ReadLine();
            int nTimes = int.Parse(Console.ReadLine());
            Console.WriteLine(Output(stringToRepeat, nTimes));
        }
        static string Output(string str, int n)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                result.Append(str);
            }
            return result.ToString();
        }
    }
}
