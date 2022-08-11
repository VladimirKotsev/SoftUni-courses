namespace CarRacing.Models.Cars
{
    using System;
    public class TunedCar : Car
    {
        private const double StartingLittersOfFuel = 65;
        private const double FuelConsumptionForRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, StartingLittersOfFuel, FuelConsumptionForRace)
        {

        }

        public override void Drive()
        {
            base.Drive();
            base.HorsePower = (int)Math.Round(base.HorsePower * 0.97, MidpointRounding.AwayFromZero);
        }
    }
}
