namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private double caffeine;

        public double Caffeine
        {
            get { return caffeine; }
            set { caffeine = value; }
        }

        public Coffee(string name, double caffeine) : base(name, 3.50m, 50)
        {
            this.Caffeine = caffeine;
        }
    }
}
