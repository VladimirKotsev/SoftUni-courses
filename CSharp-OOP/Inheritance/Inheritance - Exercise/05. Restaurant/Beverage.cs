namespace Restaurant
{

    public class Beverage : Product
    {
        private double milliliters;
        public double Milliliters
        {
            get { return milliliters; }
            set { milliliters = value; }
        }

        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            this.Milliliters = milliliters;
        }
    }
}
