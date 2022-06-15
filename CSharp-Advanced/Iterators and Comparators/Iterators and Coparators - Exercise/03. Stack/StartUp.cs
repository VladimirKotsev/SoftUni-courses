using System;
using System.Linq;
using System.Text;

namespace _03._Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> stack = new Stack<string>();
            while (input != "END")
            {
                string[] command = input.Split(' ');
                switch (command[0])
                {
                    case "Push":
                        string help = GetSb(command).ToString();
                        var push = help.Split(',');
                        stack.Push(push);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                }


                input = Console.ReadLine();
            }
            foreach (var s in stack)
            {
                Console.WriteLine(s);
            }
            foreach (var s in stack)
            {
                Console.WriteLine(s);
            }
        }
        static StringBuilder GetSb(string[] command)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < command.Length; i++)
            {
                sb.Append(command[i]);
            }
            return sb;
        }
    }
}
