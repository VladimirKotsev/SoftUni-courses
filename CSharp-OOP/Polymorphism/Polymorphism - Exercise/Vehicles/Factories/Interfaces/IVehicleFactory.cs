namespace _01._Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    public interface IVehicleFactory
    {
        public Vehicle CreateFactory
            (string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
