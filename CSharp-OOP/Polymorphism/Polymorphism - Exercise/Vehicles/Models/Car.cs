namespace _01._Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    public class Car : Vehicle
    {
        private const double CarFuelConsumptionModifier = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption; 
            protected set => base.FuelConsumption = value + CarFuelConsumptionModifier;
        }
    }
}
