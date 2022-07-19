namespace _01._Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionModifier = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + TruckFuelConsumptionModifier;
        }

        public override void Refill(double litters)
        {
            if (litters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + litters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += litters * 0.95;
            }
        }
    }
}
