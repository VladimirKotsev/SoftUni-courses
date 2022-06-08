using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var following = new Dictionary<string, List<string>>();
            // he follows
            var followers = new Dictionary<string, List<string>>();
            // he is followed by..
            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string vlogName = input.Split(' ')[0];
                string vlogName2 = input.Split(' ')[2];
                if (input.Split(' ').Length == 4) //joing -> what to do..
                {
                    if (!following.ContainsKey(vlogName))
                    {
                        following.Add(vlogName, new List<string>());
                        followers.Add(vlogName, new List<string>());
                    }
                }
                else if (input.Split(' ').Length == 3 && vlogName != vlogName2) 
                //following -> what to do..
                {
                    if (following.ContainsKey(vlogName) && following.ContainsKey(vlogName2) && !followers[vlogName2].Contains(vlogName))
                    {
                        following[vlogName].Add(vlogName2);
                        followers[vlogName2].Add(vlogName);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {following.Count} vloggers in its logs.");
            var sortedFollowers = followers.OrderBy(f => f.Value.Count).ThenByDescending(f => f.Key);
            var sorttedFollowing = following.OrderBy(f => f.Value.Count);
            foreach (var vlogger in sortedFollowers)
            {
                int n = 1;
                Console.WriteLine($"{n}. {vlogger.Key} : {vlogger.Value}");
            }
        }
    }
}
