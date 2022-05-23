﻿using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                uniqueNames.Add(Console.ReadLine());
            }
            foreach (var name in uniqueNames)
                Console.WriteLine(name);
        }
    }
}
