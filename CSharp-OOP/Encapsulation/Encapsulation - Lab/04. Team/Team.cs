namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Team
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private List<Person> firstTeam;
        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }
        private List<Person> reserveTeam;
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            { 
                reserveTeam.Add(person); 
            }
        }

        public override string ToString()
        {
            return $"First team has {this.FirstTeam.Count} players.\n\r" +
                   $"Reserve team has {this.ReserveTeam.Count} players.";
        }
    }
}
