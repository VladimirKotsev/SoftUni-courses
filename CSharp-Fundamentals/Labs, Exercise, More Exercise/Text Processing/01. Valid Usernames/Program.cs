using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validUsernames = new List<string>();
            for (int i = 0; i < usernames.Length; i++)
            {
                string user = usernames[i];
                if (user.Length >= 3 && user.Length <= 16)
                {
                    if (IfValid(user))
                    {
                        validUsernames.Add(user);
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }
        static bool IfValid(string user)
        {
            foreach(char symbol in user)
            {
                if (char.IsLetterOrDigit(symbol) || symbol == '-' || symbol == '_')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
