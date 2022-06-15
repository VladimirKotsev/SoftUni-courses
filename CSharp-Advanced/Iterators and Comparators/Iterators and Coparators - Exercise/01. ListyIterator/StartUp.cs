using System;
using System.Linq;

namespace _01._ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
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
                }
                input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
