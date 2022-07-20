namespace WildFarm.Models.Animals.Mammals.Felines
{
    using System;
    using System.Collections.Generic;
    using Foods;
    public class Cat : Feline
    {
        private const double CatWeightModifier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>()
            { typeof(Vegetable),  typeof(Meat) };

        protected override double WeightMultiplier
            => CatWeightModifier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
