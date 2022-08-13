namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Utilities;
    public class Race : IRace
    {
        private string raceName;
        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                }

                raceName = value;
            }
        }

        private int numberOfLaps;
        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                numberOfLaps = value;
            }

        }

        private bool tookPlace;
        public bool TookPlace
        {
            get { return tookPlace; }
            set 
            { 
                tookPlace = value; 
            }
        }

        private List<IPilot> pilots;
        public ICollection<IPilot> Pilots
        {
            get { return this.pilots; }
        }

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
            this.TookPlace = false;
        }

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            return $"The {this.RaceName} race has:" + Environment.NewLine +
                   $"Participants: {this.Pilots.Count}" + Environment.NewLine +
                   $"Number of laps: { this.NumberOfLaps }" + Environment.NewLine +
                   $"Took place: {this.TookPlace}";
        }
    }
}
