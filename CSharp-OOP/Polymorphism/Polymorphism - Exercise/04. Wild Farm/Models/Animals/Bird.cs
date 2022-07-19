namespace WildFarm.Models.Animals
{
    public class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }

        private double wingSize;
        public double WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }


    }
}
