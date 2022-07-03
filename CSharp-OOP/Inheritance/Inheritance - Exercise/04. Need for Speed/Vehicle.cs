namespace NeedForSpeed
{
    public class Vehicle
    {
        protected int HorsePower { get; set; }
        protected double Fuel { get; set; }

        public double DefaultFuelConsumption = 1.25;

        protected virtual double FuelConsumption;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public virtual void Drive(double kilometers)
        {

        }
    }
}
