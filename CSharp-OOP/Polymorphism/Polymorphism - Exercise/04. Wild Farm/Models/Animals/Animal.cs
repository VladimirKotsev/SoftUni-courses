namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    public abstract class Animal
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double weight;
        public double Weight
        {
            get 
            {
                return weight + (this.FoodEaten * this.WeightMultiplier);
            }
            set { weight = value; }
        }

        private int foodEaten;
        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
