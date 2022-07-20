
namespace WildFarm.Models.Animals.Mammals.Felines
{
    using System;
    using System.Collections.Generic;
    using Foods;
    public class Tiger : Feline
    {
        private const double TigerWeightModifier = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>()
            { typeof(Meat) };

        protected override double WeightMultiplier
            => TigerWeightModifier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
