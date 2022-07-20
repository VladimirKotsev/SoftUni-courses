
namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using Foods;
    public class Owl : Bird
    {
        private const double OwlWeightModifier = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>()
            { typeof(Meat) };

        protected override double WeightMultiplier
            => OwlWeightModifier;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

    }
}
