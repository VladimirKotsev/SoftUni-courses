using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songQueue = new Queue<string>();
            string[] queueSongs = Console.ReadLine().Split(", ");
            foreach (string song in queueSongs)
                songQueue.Enqueue(song);
            while (songQueue.Count != 0)
            {
                string command = Console.ReadLine();
                string[] cmd = command.Split(' ');
                switch (cmd[0])
                {
                    case "Play":
                        songQueue.Dequeue();
                        break;
                    case "Add":
                        string song = command.Substring(4, command.Length - 1 - 3);
                        if (!songQueue.Contains(song))
                            songQueue.Enqueue(song);
                        else
                            Console.WriteLine($"{song} is already contained!");
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", songQueue));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
