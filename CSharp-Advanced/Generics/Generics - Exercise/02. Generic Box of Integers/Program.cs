using System;

namespace _02._Generic_Box_of_Integers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                var input = Console.ReadLine();
                var item = int.Parse(input);
                Console.WriteLine(new Box<int>(item));
            }
        }
    }
}
