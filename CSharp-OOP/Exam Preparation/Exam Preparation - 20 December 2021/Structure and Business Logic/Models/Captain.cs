namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;

    public class Captain : ICaptain
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            private set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                fullName = value; 
            }
        }

        private int combatExperience;
        public int CombatExperience
        {
            get { return combatExperience; }
            private set
            {
                combatExperience = value;
            }
        }

        private List<IVessel> vessels;
        public ICollection<IVessel> Vessels
        {
            get { return vessels; }
        }

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.vessels = new List<IVessel>();
            this.CombatExperience = 0;
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel is null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Count > 0)
            {
                foreach (var vessel in this.Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
