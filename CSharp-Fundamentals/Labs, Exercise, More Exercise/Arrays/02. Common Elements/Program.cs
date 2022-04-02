using System;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ");
            string[] secondArray = Console.ReadLine().Split(" ");
            for (int i = 0; i < secondArray.Length; i++) // 10, hey, 4, hello
            {
                for (int j = 0; j < firstArray.Length; j++)  //Hey, hello, 2, 4
                {
                    if(firstArray[j] == secondArray[i])
                    {
                        Console.Write(firstArray[j] + " ");
                    }
                }
            }
        }
    }
}
