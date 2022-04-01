using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> finalResult = new List<int>();
            int count = firstList.Count + secondList.Count;
            int i = 0;
            while (finalResult.Count != count)
            {
                if (i % 2 == 0)
                {
                    if (firstList.Count >= 1)
                    {
                        finalResult.Add(firstList[0]);
                        firstList.RemoveAt(0);
                    }
                }
                else
                {
                    if (secondList.Count >= 1)
                    {
                        finalResult.Add(secondList[0]);
                        secondList.RemoveAt(0);
                    }
                }
                i++;
            }
            Console.WriteLine(String.Join(" ", finalResult));
        }
    }
}
