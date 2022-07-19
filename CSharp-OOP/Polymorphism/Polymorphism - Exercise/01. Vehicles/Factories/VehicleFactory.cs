
namespace _01._Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    using Core;
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateFactory
            (string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new ArgumentException("Invalid type of vehicle");
            }

            return vehicle;

        }
    }
}
