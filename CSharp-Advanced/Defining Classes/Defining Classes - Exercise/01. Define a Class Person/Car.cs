using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private double fuelAmount;
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        private double fuelConsumptionPerKilometer;
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        private double travelledDistance;
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
        public Car()
        {

        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0; 
        }
        public List<Car> Drive(List<Car> cars, string car, int kilometers)
        {
            int index = cars.FindIndex(x => x.Model.Equals(car));
            double consumped = kilometers * cars[index].FuelConsumptionPerKilometer;
            if (consumped <= cars[index].FuelAmount)
            {
                cars[index].FuelAmount -= consumped;
                cars[index].TravelledDistance += kilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            return cars;
        }
    }
}
