namespace _05._Football_Team_Generator
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> teamNames = new List<string>();
            List<Team> teams = new List<Team>();

            string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            Team team = null;

            while (input[0] != "END")
            {
                if (input[0] == "Team")
                {
                    try
                    {
                        team = new Team(input[1]);

                        teams.Add(team);
                        teamNames.Add(input[1]);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else if (input[0] == "Add")
                {
                    if (!teamNames.Contains(input[1]))
                    {
                        Console.WriteLine($"Team {input[1]} does not exist.");
                    }
                    else
                    {
                        try
                        {
                            Player player = new Player
                                (input[2], int.Parse(input[3]), 
                                int.Parse(input[4]), int.Parse(input[5]),
                                int.Parse(input[6]), int.Parse(input[7]));

                            foreach(var t in teams)
                            {
                                if (t.Name == input[1])
                                    t.AddPlayer(player);
                            }
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                    }

                }
                else if (input[0] == "Remove")
                {
                    foreach (var t in teams)
                    {
                        if (t.Name == input[1])
                        {
                            t.RemovePlayer(input[2]);
                        }
                    }
                }
                else if (input[0] == "Rating")
                {
                    if (!teamNames.Contains(input[1]))
                        Console.WriteLine($"Team {input[1]} does not exist.");
                    else
                    {
                        foreach (var t in teams)
                        {
                            if (t.Name == input[1])
                            {
                                Console.WriteLine(t.Rating);
                            }
                        }
                    }
                }



                input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
