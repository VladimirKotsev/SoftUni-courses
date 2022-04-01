using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List <string> listOfPorducts = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                listOfPorducts.Add(Console.ReadLine());
            }
            listOfPorducts.Sort();
            for (int i = 1; i <= listOfPorducts.Count; i++)
            {
                Console.WriteLine($"{i}.{listOfPorducts[i-1]}");
            }
        }
    }
}
