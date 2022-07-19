namespace WildFarm.Models.Animals.Mammals
{
    public class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        private string breed;
        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

    }
}
