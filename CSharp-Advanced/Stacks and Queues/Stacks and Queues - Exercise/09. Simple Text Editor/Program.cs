using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Stack<string> text = new Stack<string>();
            text.Push(null);
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                switch (cmd[0])
                {
                    case "1":
                        sb.Append(cmd[1]);
                        text.Push(sb.ToString());
                        break;
                    case "2":
                        sb.Remove(sb.Length - int.Parse(cmd[1]), int.Parse(cmd[1]));
                        text.Push(sb.ToString());
                        break;
                    case "3":
                        Console.WriteLine(sb[int.Parse(cmd[1]) - 1]);
                        break;
                    case "4":
                        if (text.Peek() == sb.ToString())
                        {
                            text.Pop();
                        }
                        sb.Clear();
                        sb.Append(text.Pop());
                        break;
                }
            }
        }
    }
}
