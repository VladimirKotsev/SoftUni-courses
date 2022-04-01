using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] theArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int firstNumber = theArray[0];
                for (int j = 0; j < theArray.Length - 1; j++)
                {
                    theArray[j] = theArray[j + 1];
                }
                theArray[theArray.Length - 1] = firstNumber;
            }
            Console.WriteLine(string.Join(" ", theArray));
        }
    }
}
