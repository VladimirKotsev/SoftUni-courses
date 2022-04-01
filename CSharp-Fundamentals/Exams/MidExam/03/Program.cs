using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            string JohnIsWild = Console.ReadLine();
            int sumLeft = SumOfLeft(priceRatings, entryPoint, JohnIsWild);
            int sumRight = SumOfRight(priceRatings, entryPoint, JohnIsWild);
            if (sumLeft >= sumRight)
            {
                Console.WriteLine($"Left - {sumLeft}");
            }
            else
            {
                Console.WriteLine($"Right - {sumRight}");
            }
        }
        static int SumOfLeft(int[] array, int entryPoint, string john)
        {
            int sum = 0;
            int index = array[entryPoint];
            for (int i = entryPoint - 1; i >= 0; i--)
            {
                switch(john)
                {
                    case "expensive":
                        if (array[i] >= index)
                        {
                            sum += array[i];
                        }
                        break;
                    case "cheap":
                        if (array[i] < index)
                        {
                            sum += array[i];
                        }
                        break;
                }
            }
            return sum;
        }
        static int SumOfRight(int[] array, int entryPoint, string john)
        {
            int sum = 0;
            int index = array[entryPoint];
            for (int i = entryPoint + 1; i < array.Length; i++)
            {
                switch (john)
                {
                    case "expensive":
                        if (array[i] >= index)
                        {
                            sum += array[i];
                        }
                        break;
                    case "cheap":
                        if (array[i] < index)
                        {
                            sum += array[i];
                        }
                        break;
                }
            }
            return sum;
        }
    }
}
