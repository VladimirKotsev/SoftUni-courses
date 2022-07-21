namespace _05._Football_Team_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private List<Player> players;
        public List<Player> Players
        {
            get { return players; }
            private set { players = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("A name should not be empty.");
                name = value;
            }
        }

        public string Rating
        {
            get => $"{this.Name} - {CalculateRatingOfTeam()}";
        }

        private int CalculateRatingOfTeam()
        {
            List<double> list = new List<double>();
            foreach (var player in this.Players)
            {
                list.Add(player.RatingPlayer);
            }

            if (list.Count == 0)
                return 0;

            return (int)Math.Round(list.Average(), MidpointRounding.AwayFromZero);
        }

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            int index = this.players.FindIndex(x => x.Name == name);

            if (index == -1)
                Console.WriteLine($"Player {name} is not in {this.Name} team.");
            else
                players.RemoveAt(index);
        }
    }
}
