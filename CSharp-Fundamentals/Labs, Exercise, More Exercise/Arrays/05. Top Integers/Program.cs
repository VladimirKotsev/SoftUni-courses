using System;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] outputArray = new int[array.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool IsGreater = true;
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[i] <= array[j])
                    {
                        IsGreater = false;
                        break;
                    }
                    
                }
                if (IsGreater)
                {
                    outputArray[count] = array[i];
                    count++;
                }
                //if (IsGreater)
                //{
                //    Console.Write(array[i] + " ");
                //}
            }
            Console.Write(array[array.Length - 1]);
        }
    }
}
