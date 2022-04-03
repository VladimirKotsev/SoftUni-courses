using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int index = length - 1;
            int sample = 0;
            int countFor = 1;
            int sum = 0;
            int outputSum = 0;
            int[] outputArray = new int[length];
            while (input != "Clone them!")
            {
                sum = 0;
                int[] DNA = input.Split('!').Select(int.Parse).ToArray();
                sum += DNA[length - 1];
                for (int i = 0; i < DNA.Length - 1; i++)
                {
                    if (DNA[i] == DNA[i + 1])
                    {
                        if (i < index)
                        {
                            sum += DNA[i];
                            sample = countFor;
                            index = i;
                            outputArray = DNA;
                            outputSum = sum;
                        }
                    }
                }
                countFor++;

                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {sample} with sum: {outputSum + 1}.");
            Console.WriteLine(String.Join(' ', outputArray));
        }
    }
}
