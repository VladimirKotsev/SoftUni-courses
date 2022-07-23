namespace _07._Military_Elite.Models
{
    using System;
    using Intefaces;
    using System.Collections.Generic;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Mission>();
        }

        private List<Mission> missions;
        public IReadOnlyCollection<Mission> Missions
        {
            get
            {
                return missions.AsReadOnly();
            }
        }
        public void CompleteMission()
        {
            
        }

        public void AddMission(Mission mission)
        {      
            missions.Add(mission);
        }

        public override string ToString()
        {
            if (this.Missions.Count == 0)
            {
                return base.ToString() + $"{Environment.NewLine}" +
                      $"Corps: {this.Corps}{Environment.NewLine}" +
                      $"Missions:";

            }
            return base.ToString() + $"{Environment.NewLine}" +
                   $"Corps: {this.Corps}{Environment.NewLine}" +
                   $"Missions:{Environment.NewLine}"
                   + "  " + String.Join(Environment.NewLine + "  ", this.Missions);
        }
    }
}
