using System;

namespace _04._Generic_Swap_Method_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 1; i <= n; i++)
            {
                var input = Console.ReadLine();
                var item = int.Parse(input);
                box.List.Add(item);
            }

            string[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int index1 = int.Parse(input2[0]);
            int index2 = int.Parse(input2[1]);

            box.Swap(index1, index2);
            box.Print();
        }
    }
}
