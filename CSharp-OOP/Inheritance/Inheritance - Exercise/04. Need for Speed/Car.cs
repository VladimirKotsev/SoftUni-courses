namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            
        }

        public override void Drive(double kilometers)
        {
            double fuel = this.Fuel - 3 * kilometers;
            this.Fuel = fuel;
        }
    }
}
