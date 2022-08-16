
namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;

    using Utilities.Messages;
    using Contracts;
    using Easter.Models.Dyes.Contracts;

    public abstract class Bunny : IBunny
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value; 
            }
        }

        private int energy;
        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }

                energy = value;
            }
        }

        private List<IDye> dyes;
        public ICollection<IDye> Dyes
        {
            get { return dyes; }
        }

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }

        public virtual void Work()
        {
            this.Energy -= 10;
        }
        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }

    }
}
