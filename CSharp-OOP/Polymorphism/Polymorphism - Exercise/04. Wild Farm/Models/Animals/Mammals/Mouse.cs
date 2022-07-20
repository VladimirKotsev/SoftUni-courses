namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;
    using Foods;
    public class Mouse : Mammal
    {
        private const double MouseWeightModifier = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>()
            { typeof(Vegetable), typeof(Fruit)};

        protected override double WeightMultiplier
            => MouseWeightModifier;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
