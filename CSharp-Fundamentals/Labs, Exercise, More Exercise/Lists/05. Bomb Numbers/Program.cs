using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int[] array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int specialNumber = array[0];
            int power = array[1];
            int sum = 0;
            int count = 2 * power + 1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == specialNumber)
                {
                    int indexBomb = i;
                    int j = 0;
                    while (j != count)
                    {
                        if (indexBomb == 0)
                        {
                            while (j != count)
                            {
                                if (indexBomb - power > list.Count - 1)
                                {
                                    list.RemoveAt(list.Count - 1);
                                }
                                else
                                {
                                    list.RemoveAt(indexBomb - power);
                                }
                                j++;
                            }
                            
                        }
                        else if (indexBomb - power >= 0)
                        {
                            while (j != count)
                            {
                                if (indexBomb - power > list.Count - 1)
                                {
                                    list.RemoveAt(list.Count - 1);
                                }
                                else
                                {
                                    list.RemoveAt(indexBomb - power);
                                }
                                j++;
                            }

                        }
                    }
                }
            }
            foreach (int i in list)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
