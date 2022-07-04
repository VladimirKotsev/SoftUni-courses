namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public override void Drive(double kilometers)
        {
            double fuel = this.Fuel - 10 * kilometers;
            this.Fuel = fuel;
        }
    }
}
