using System;
using System.Linq;

namespace _04._Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] rocks = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            Lake lake = new Lake(rocks);
            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
