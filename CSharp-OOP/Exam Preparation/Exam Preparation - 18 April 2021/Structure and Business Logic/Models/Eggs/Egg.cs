namespace Easter.Models.Eggs
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public class Egg : IEgg
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                name = value;
            }
        }

        private int energyRequired;
        public int EnergyRequired
        {
            get { return energyRequired; }
            private set
            {
                if (value < 0)
                {
                    energyRequired = 0;
                }

                energyRequired = value;
            }
        }

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            return EnergyRequired == 0;
        }
    }
}
