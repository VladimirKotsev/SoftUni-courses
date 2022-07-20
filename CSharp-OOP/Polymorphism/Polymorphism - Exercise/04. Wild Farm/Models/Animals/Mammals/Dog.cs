
namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;
    using Foods;
    public class Dog : Mammal
    {
        private const double DogWeightModifier = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>()
            { typeof(Meat)};

        protected override double WeightMultiplier
            => DogWeightModifier;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
