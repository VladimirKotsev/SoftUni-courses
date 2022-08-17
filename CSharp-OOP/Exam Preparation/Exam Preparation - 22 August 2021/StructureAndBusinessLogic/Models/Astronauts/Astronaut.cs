namespace SpaceStation.Models.Astronauts
{
    using System;

    using Contracts;
    using Models.Bags;
    using Models.Bags.Contracts;
    using Utilities.Messages;
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        private double oxygen;
        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }


        public bool CanBreath
        {
            get { return this.Oxygen > 0; }
        }

        private IBag bag;
        public IBag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public virtual void Breath()
        {
            this.Oxygen -= 10;
        }
    }
}
