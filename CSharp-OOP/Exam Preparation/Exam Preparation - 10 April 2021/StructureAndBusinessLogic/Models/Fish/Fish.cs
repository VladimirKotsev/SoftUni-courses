namespace AquaShop.Models.Fish
{
    using System;

    using Contracts;
    using Utilities.Messages;
    public abstract class Fish : IFish
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);              
                }

                name = value; 
            }
        }

        private string species;
        public string Species
        {
            get { return species; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }

                species = value;
            }
        }

        private int size;
        public int Size
        {
            get { return size; }
            protected set
            {
                size = value;
            }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                price = value;
            }
        }

        public Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public abstract void Eat();
    }
}
