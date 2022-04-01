using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int sum = 0;
            int count = 0;
            int index = 0;
            int maxCount = -10000;
            while (input != "Clone them!")
            {
                int[] array = input.Split("!").Select(int.Parse).ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                    if (array[i] == array[i + 1])
                    {
                        count++;
                        if (count > maxCount)
                        {
                            index = i;
                        }
                    }
                }
            }
        }
    }
}
