namespace _01._Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public string Drive(double kilometers);

        public void Refill(double litters);
    }
}
