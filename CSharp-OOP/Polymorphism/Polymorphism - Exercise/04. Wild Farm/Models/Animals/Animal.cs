namespace WildFarm.Models
{
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
            get { return weight; }
            set { weight = value; }
        }

        private int foodEaten;
        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }
        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public abstract string ProduceSound();


    }
}
