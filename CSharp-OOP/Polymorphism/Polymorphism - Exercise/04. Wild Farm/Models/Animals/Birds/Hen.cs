namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using Foods;
    public class Hen : Bird
    {
        private const double HenWeightModifier = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }


        protected override double WeightMultiplier
            => HenWeightModifier;

        public override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>
                    { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) }
                .AsReadOnly();

        public override string ProduceSound()
        {
            return "Cluck";
        }


    }
}
