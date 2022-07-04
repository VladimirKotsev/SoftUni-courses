namespace NeedForSpeed
{
    public class Vehicle
    {
        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        private const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public virtual void Drive(double kilometers)
        {
            double fuel = this.Fuel - DefaultFuelConsumption * kilometers;
            this.Fuel = fuel;
        }
    }
}
