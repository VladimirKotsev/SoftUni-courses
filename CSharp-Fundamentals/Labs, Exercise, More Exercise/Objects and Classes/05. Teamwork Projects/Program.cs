using System;     
using System.Collections.Generic;
using System.Linq;
 
public class Team
{
    public string TeamName { get; set; }

    public string Creator { get; set; }

    public List<string> Members { get; set; }
    public Team (string teamName, string creator)
    {
        this.TeamName = teamName;
        this.Creator = creator;
        this.Members = new List<string>();
    }
}
public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Team> teams = new List<Team>();
        for (int i = 1; i <= n; i++)
        {
            string[] input1 = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
            if (!teams.Select(x =>x.TeamName).Contains(input1[1]) && !teams.Select(x =>x.Creator).Contains(input1[0])) //Both the opposite way
            {
                Team myTeam = new Team(input1[1], input1[0]);
                teams.Add(myTeam);
                Console.WriteLine($"Team {input1[1]} has been created by {input1[0]}!");
            }
            else if (teams.Select(x => x.TeamName).Contains(input1[1])) //If team allready exists!
            {
                Console.WriteLine($"Team {input1[1]} was already created!");
            }
            else if (teams.Select(x => x.Creator).Contains(input1[0])) //If a creator already has a team
            {
                Console.WriteLine($"{input1[0]} cannot create another team!");
            }
        }
        string input = Console.ReadLine();
        while (input != "end of assignment")
        {
            string[] input2 = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
            if (teams.Select(x=>x.TeamName).Contains(input2[1]) && !teams.Select(x => x.Creator).Contains(input2[0]) && !teams.Any(x => x.Members.Contains(input2[0]))) //Both the opposite way
            {
                int index = teams.FindIndex(x => x.TeamName == input2[1]);
                teams[index].Members.Add(input2[0]);
            }
            else if (!teams.Select(x => x.TeamName).Contains(input2[1])) //If team exists
            {
                Console.WriteLine($"Team {input2[1]} does not exist!");
            }
            else if (teams.Select(x => x.Creator).Contains(input2[0]) || teams.Any(t => t.Members.Contains(input2[0]))) //If a player is trying to cheat
            {
                Console.WriteLine($"Member {input2[0]} cannot join team {input2[1]}!");
            }
            input = Console.ReadLine();
        }
        PrintExit(teams.OrderByDescending(x => x.Members.Count).ThenBy(t => t.TeamName).ToList());

    }
    static void PrintExit(List<Team> list)
    {
        List<Team> toDisband = new List<Team>();
        foreach(Team team in list)
        {
            if (team.Members.Count > 0)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                team.Members.Sort();
                Console.WriteLine(string.Join(Environment.NewLine, team.Members.Select(x => "-- " + x)));
            }
            else if (team.Members.Count <= 0)
            {
                toDisband.Add(team);
            }
        }
        Console.WriteLine("Teams to disband:");
        toDisband = toDisband.OrderBy(x => x.TeamName).ToList();
        foreach (Team team in toDisband)
        {
            Console.WriteLine(team.TeamName);
        }
    }
}
