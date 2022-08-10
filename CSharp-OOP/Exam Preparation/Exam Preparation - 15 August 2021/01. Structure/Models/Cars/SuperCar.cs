namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double StartingLittersOfFuel = 80;
        private const double FuelConsumptionForRace = 10;


        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, StartingLittersOfFuel, FuelConsumptionForRace)
        {

        }
    }
}
