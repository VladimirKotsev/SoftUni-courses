using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            string invite = Console.ReadLine();
            while (invite != "PARTY")
            {
                char[] c = invite.ToCharArray();
                if (Char.IsDigit(c[0]))
                    vip.Add(invite);
                else
                    regular.Add(invite);
                invite = Console.ReadLine();
            }
            string entry = Console.ReadLine();
            while (entry != "END")
            {
                if (vip.Contains(entry))
                    vip.Remove(entry);
                else if (regular.Contains(entry))
                    regular.Remove(entry);
                entry = Console.ReadLine();
            }
            Console.WriteLine(vip.Count + regular.Count);
            foreach (string inv in vip)
            {
                Console.WriteLine(inv);
            }
            foreach (string inv in regular)
            {
                Console.WriteLine(inv);
            }
        }
    }
}
