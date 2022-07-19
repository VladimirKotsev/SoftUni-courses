namespace WildFarm.Models.Animals
{
    public class Mammal : Animal
    {
        public Mammal(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        private string livingRegion;
        public string LivingRegion
        {
            get { return livingRegion; }
            set { livingRegion = value; }
        }

    }
}
