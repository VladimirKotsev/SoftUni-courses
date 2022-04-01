using System;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = Console.ReadLine().Split('\\');
            string[] info = file[file.Length - 1].Split(".");
            Console.WriteLine($"File name: {info[0]}");
            Console.WriteLine($"File extension: {info[1]}");
        }
    }
}
