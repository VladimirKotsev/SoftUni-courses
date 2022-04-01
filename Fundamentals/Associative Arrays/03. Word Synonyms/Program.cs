using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
            for (int i = 1; i <= n; i++)
            {          
                string word = Console.ReadLine();
                string synonymOfWord = Console.ReadLine();
                if (synonyms.ContainsKey(word))
                {
                    synonyms[word].Add(synonymOfWord);
                }
                else
                {
                    List<string> list = new List<string>() { synonymOfWord };
                    synonyms.Add(word, list);
                }
            }
            foreach(var synonym in synonyms)
            {
                Console.WriteLine($"{synonym.Key} - {string.Join(", ", synonym.Value)}");
            }
        }
    }
}
