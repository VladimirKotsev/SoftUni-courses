using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] rawArray = Console.ReadLine().Split();
            //int[] array = new int[rawArray.Length];
            //for (int i = 0; i < rawArray.Length; i++)
            //{
            //    array[i] = int.Parse(rawArray[i]);
            //}
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int arrayLength = array.Length - 1;
            int sum = 0;
            int[] belovedArray = new int[arrayLength];
            if (array.Length == 1)
            {
                Console.WriteLine(array[0]);
                return;
            }
            while (arrayLength > 0)
            {
                belovedArray = new int[arrayLength];
                for (int i = 0; i < arrayLength; i++)
                {
                    belovedArray[i] = array[i] + array[i + 1];
                    sum = belovedArray[i];
                }
                arrayLength--;
                array = belovedArray;
            }

            Console.WriteLine(sum);
        }
    }
}
