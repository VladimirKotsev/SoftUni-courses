using System;
using System.Linq;

namespace _02._Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ListyIterator<string> listy = new ListyIterator<string>();
            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "Create":
                        listy = new ListyIterator<string>(input.Skip(1).ToArray());
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        listy.Print();
                        break;
                    case "PrintAll":
                        listy.PrintAll();
                        Console.WriteLine();
                        break;
                }
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
