namespace Gym.Models.Athletes
{
    using System;

    using Contracts;
    using Utilities.Messages;
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                fullName = value;
            }
        }

        private string motivation;
        public string Motivation
        {
            get { return motivation; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }

                motivation = value;
            }
        }

        private int stamina;
        public int Stamina
        {
            get { return stamina; }
            protected set 
            {
                if (value > 100)
                {
                    stamina = 100;
                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }

                stamina = value; 
            }
        }

        private int numberOfMedals;
        public int NumberOfMedals
        {
            get { return numberOfMedals; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }

                numberOfMedals = value;
            }
        }

        public Athlete(string fullName, string motivation, int stamina, int numberOfMedals)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.Stamina = stamina;
            this.NumberOfMedals = numberOfMedals;
        }

        public abstract void Exercise();
    }
}
