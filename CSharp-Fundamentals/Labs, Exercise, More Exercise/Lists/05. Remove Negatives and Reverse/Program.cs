using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> checkList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < checkList.Count; i++)
            {
                if (checkList[i] < 0)
                {
                    checkList.RemoveAt(i);
                    i--;
                }
            }
            
            if (checkList.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                checkList.Reverse();
                Console.WriteLine(String.Join(" ", checkList));
            }
        }
    }
}
