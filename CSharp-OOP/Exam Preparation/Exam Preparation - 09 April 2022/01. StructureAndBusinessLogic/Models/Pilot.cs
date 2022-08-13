namespace Formula1.Models
{
    using System;

    using Utilities;
    using Contracts;
    public class Pilot : IPilot
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (value.Length < 5 || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
                }

                fullName = value;
            }
        }

        private IFormulaOneCar car;
        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value is null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }

                car = value;
            }
        }

        private int numberOfWins;
        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }

        private bool canRace;
        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }

        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.CanRace = false;
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
