namespace PlanetWars.Models.Weapons
{
    using System;

    using Utilities.Messages;
    using Contracts;
    public abstract class Weapon : IWeapon
    {
        private double price;
        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        private int destructionLevel;
        public int DestructionLevel
        {
            get { return destructionLevel; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }

                destructionLevel = value; 
            }
        }

        protected Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }
    }
}
