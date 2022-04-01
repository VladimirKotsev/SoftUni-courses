using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phrase = new List<string>()
                {"Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };

            List<string> events = new List<string>()

                {"Now I feel good.",
                    "I have succeeded with this product.",
                    "Makes miracles. I am happy of the results!",
                    "I cannot believe but now I feel awesome.",
                    "Try it yourself, I am very satisfied.",
                    "I feel great!" };
            List<string> author = new List<string>()
                {"Diana", 
                "Petya", 
                "Stella", 
                "Elena", 
                "Katya", 
                "Iva", 
                "Annie", 
                "Eva"};
            List<string> city = new List<string>()
                {"Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"};
            Random rnd = new Random();
            Console.WriteLine($"{phrase[rnd.Next(1, phrase.Count)]} {events[rnd.Next(1, events.Count)]} {author[rnd.Next(1, author.Count)]} – {city[rnd.Next(1, city.Count)]}.");


        }

    }
}

