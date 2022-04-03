using System;
using System.Text;

namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder password = new StringBuilder(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] cmd = command.Split(' ');
                switch (cmd[0])
                {
                    case "TakeOdd":
                        password = TakeOddMethod(password);
                        Console.WriteLine(password.ToString());
                        break;
                    case "Cut":
                        password = CutMethod(password, int.Parse(cmd[1]), int.Parse(cmd[2]));
                        Console.WriteLine(password.ToString());
                        break;
                    case "Substitute":
                        password = SubstituteMethod(password, cmd[1], cmd[2]);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
        static StringBuilder TakeOddMethod(StringBuilder sb)
        {
            StringBuilder afterEditPassword = new StringBuilder();
            for (int i = 1; i < sb.Length; i += 2)
            {
                afterEditPassword.Append(sb[i]);
            }
            return afterEditPassword;
        }
        static StringBuilder CutMethod(StringBuilder sb, int index, int toRemove)
        {
            sb = sb.Remove(index, toRemove);
            return sb;
        }
        static StringBuilder SubstituteMethod(StringBuilder sb, string substring, string substitute)
        {
            string sbInString = sb.ToString();
            if (sbInString.Contains(substring))
            {
                sb = sb.Replace(substring, substitute);
                Console.WriteLine(sb);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }
            return sb;
        }
    }
}
