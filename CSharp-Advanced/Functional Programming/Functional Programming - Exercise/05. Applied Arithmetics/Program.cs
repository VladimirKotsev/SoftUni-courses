using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string cmd = Console.ReadLine();
            Func<int[], int[]> func = null;
            while (cmd != "end")
            {
                switch(cmd)
                {
                    case "add": func = x => x.Select(t => t += 1).ToArray();
                        array = func(array);
                        break;
                    case "multiply": func = x => x.Select(t => t *= 2).ToArray();
                        array = func(array);
                        break;
                    case "subtract": func = x => x.Select(t => t -= 1).ToArray();
                        array = func(array);
                        break;
                    case "print":
                        Array.ForEach(array,x => Console.Write(x + " "));
                        Console.WriteLine();
                        break;
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
