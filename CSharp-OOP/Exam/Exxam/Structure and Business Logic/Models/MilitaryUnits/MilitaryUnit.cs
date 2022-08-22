namespace PlanetWars.Models.MilitaryUnits
{
    using System;

    using Contracts;
    using Utilities.Messages;
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        public double Cost
        {
            get { return cost; }
            private set { cost = value; }
        }

        private int enduranceLevel;
        public int EnduranceLevel
        {
            get { return enduranceLevel; }
            private set 
            {
                enduranceLevel = value; 
            }
        }

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }

        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel + 1 == 21)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
            this.EnduranceLevel++;
        }
    }
}
