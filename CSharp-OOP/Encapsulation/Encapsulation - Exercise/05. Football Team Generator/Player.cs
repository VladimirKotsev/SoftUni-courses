namespace _05._Football_Team_Generator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Player
    {
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

        private int endurance;
        public int Endurance
        {
            get { return endurance; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                endurance = value; 
            }
        }

        private int sprint;
        public int Sprint
        {
            get { return sprint; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                sprint = value; 
            }
        }

        private int dribble;
        public int Dribble
        {
            get { return dribble; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                dribble = value; 
            }
        }

        private int passing;
        public int Passing
        {
            get { return passing; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                passing = value; 
            }
        }

        private int shooting;
        public int Shooting
        {
            get { return shooting; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                shooting = value; 
            }
        }

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public double RatingPlayer
        {
            get 
            {
                List<int> list = new List<int>()
                { this.Endurance, this.Sprint, this.Dribble, this.Passing, this.Shooting};

                return list.Average();
            }
        }
    }
}
