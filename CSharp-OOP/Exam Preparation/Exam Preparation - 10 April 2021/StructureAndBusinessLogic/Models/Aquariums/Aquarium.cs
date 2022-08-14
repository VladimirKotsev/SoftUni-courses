namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using Contracts;
    using Utilities.Messages;
    public class Aquarium : IAquarium
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public int Comfort
        {
            get 
            {
                int sum = 0;

                foreach(var decoration in this.decorations)
                {
                    sum += decoration.Comfort;
                }

                return sum;
            }
        }

        private readonly List<IDecoration> decorations;
        public ICollection<IDecoration> Decorations
        {
            get { return decorations.AsReadOnly(); }
        }

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<IFish>();
            this.decorations = new List<IDecoration>();
        }

        private readonly List<IFish> fish;
        public ICollection<IFish> Fish
        {
            get { return fish.AsReadOnly(); }
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity == this.fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }
        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }


        public void Feed()
        {
            foreach(var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            if (fish.Count == 0)
            {
                return $"{this.Name} ({this.GetType().Name}):" + Environment.NewLine +
                       $"Fish: none" + Environment.NewLine +
                       $"Decorations: {this.decorations.Count}" + Environment.NewLine +
                       $"Comfort: {this.Comfort}" + Environment.NewLine;
            }
            else
            {
                return $"{this.Name} ({this.GetType().Name}):" + Environment.NewLine +
                       $"Fish: {String.Join(", ", this.fish.Select(x => x.Name))}" + Environment.NewLine +
                       $"Decorations: {this.decorations.Count}" + Environment.NewLine +
                       $"Comfort: {this.Comfort}" + Environment.NewLine;
            }
        }

    }
}
