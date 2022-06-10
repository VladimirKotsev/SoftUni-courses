using System;
using System.Collections.Generic;

namespace _03._Generic_Swap_Method_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 1; i <= n; i++)
            {
                var input1 = Console.ReadLine();
                box.Data.Add(input1);
            }
            string[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int index1 = int.Parse(input2[0]);
            int index2 = int.Parse(input2[1]);
            
            box.Swap(index1, index2);
            box.Print();
        }
    }
}
