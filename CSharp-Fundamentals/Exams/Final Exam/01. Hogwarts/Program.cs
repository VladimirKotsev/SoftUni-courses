using System;
using System.Text;

namespace _01._Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder spell = new StringBuilder();
            string s = Console.ReadLine();
            spell.Append(s);
            string command = Console.ReadLine();
            while (command != "Abracadabra")
            {
                string[] cmd = command.Split(' ');
                switch (cmd[0])
                {
                    case "Abjuration": 
                        s = spell.ToString();
                        s = s.ToUpper();
                        spell.Clear();
                        spell.Append(s);
                        Console.WriteLine(spell.ToString());
                        break;

                    case "Necromancy":
                        s = spell.ToString();
                        s = s.ToLower();
                        spell.Clear();
                        spell.Append(s);
                        Console.WriteLine(spell.ToString());
                        break;

                    case "Illusion": int index = int.Parse(cmd[1]);
                        if (index > spell.Length - 1)
                        {
                            Console.WriteLine("The spell was too weak.");
                        }
                        else
                        {
                            spell[index] = char.Parse(cmd[2]);
                            Console.WriteLine("Done!");
                        }
                        break;

                    case "Divination":
                        spell.Replace(cmd[1], cmd[2]);
                        Console.WriteLine(spell.ToString());
                        break;

                    case "Alteration": s = spell.ToString();
                        if (s.Contains(cmd[1]))
                        {
                            spell.Replace(cmd[1], "");
                            Console.WriteLine(spell.ToString());
                        }
                        break;
                    default: Console.WriteLine("The spell did not work!"); break;
                }
                command = Console.ReadLine();
            }

        }
    }
}
