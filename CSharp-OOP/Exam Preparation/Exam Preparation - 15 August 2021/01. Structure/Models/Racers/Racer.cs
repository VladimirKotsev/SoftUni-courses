namespace CarRacing.Models.Racers
{
    using System;
    using CarRacing.Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;
    public abstract class Racer : IRacer
    {
        private string username;
        public string Username
        {
            get { return username; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidRacerName);
                }

                username = value;
            }
        }

        private string racingBehavior;
        public string RacingBehavior
        {
            get { return racingBehavior; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                racingBehavior = value;
            }
        }

        private int drivingExperience;
        public int DrivingExperience
        {
            get { return drivingExperience; }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                drivingExperience = value;
            }
        }

        private ICar car;
        public ICar Car
        {
            get { return car; }
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                car = value;
            }
        }

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public bool IsAvailable()
        {
            return car.FuelAvailable >= car.FuelConsumptionPerRace;
        }

        public virtual void Race()
        {
            this.Car.Drive();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Username}" + Environment.NewLine +
                   $"--Driving behavior: {this.RacingBehavior}" + Environment.NewLine +
                   $"--Driving experience: {this.DrivingExperience}" + Environment.NewLine +
                   $"--Car: {this.car.Make} { this.car.Model} ({this.car.VIN})" + Environment.NewLine;
        }
    }
}
