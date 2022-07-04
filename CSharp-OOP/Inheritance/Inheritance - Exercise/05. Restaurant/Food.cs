namespace Restaurant
{

    public class Food : Product
    {
        private double grams;
        public double Grams
        {
            get { return grams; }
            set { grams = value; }
        }

        public Food(string name, decimal price, double grams) : base(name, price)
        {
            this.Grams = grams;
        }
    }
}
