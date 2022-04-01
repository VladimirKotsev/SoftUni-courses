using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int digit = 1;
            int length = 0;
            int count = 0;
            int maxCount = -100000;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        digit = array[i];
                        length = count;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            length += 1;
            int[] outputArray = new int[length];
            for (int i = 0; i < length;i++)
            {
                outputArray[i] = digit;
            }
            Console.WriteLine(string.Join(" ", outputArray));
        }
    }
}
