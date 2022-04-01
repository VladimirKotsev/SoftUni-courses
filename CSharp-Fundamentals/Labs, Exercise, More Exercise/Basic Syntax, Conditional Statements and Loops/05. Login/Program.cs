using System;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string passEntry = Console.ReadLine();
            string[] pass = new string[username.Length];
            int count = 1;
            int j = 0;
            for (int i = username.Length - 1; i >= 1; i--)
            {
                char letter = username[i];
                while (letter != passEntry[j])
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    count++;
                    if (count == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                    passEntry = Console.ReadLine();
                }
                j++;
            }
            Console.WriteLine($"User {username} logged in.");
        }
    }
}
