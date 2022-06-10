using System;

namespace Generic_Box_of_String
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                var item = Console.ReadLine();
                Console.WriteLine(new Box<string>(item));
            }
        }
    }
}
