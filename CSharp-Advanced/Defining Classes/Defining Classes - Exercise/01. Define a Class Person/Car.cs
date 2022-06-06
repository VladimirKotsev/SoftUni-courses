using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Engine engine;
        public List<Tires> tires = new List<Tires>();
        public Cargo cargo;
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
        public Car
            (string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, List<string> infoTire1, List<string> infoTire2, List<string> infoTire3, List<string> infoTire4)
        {
            this.Model = model;
            this.engine = new Engine(engineSpeed, enginePower);
            this.cargo = new Cargo(cargoWeight, cargoType);
            tires.Add(new Tires(double.Parse(infoTire1[0]), int.Parse(infoTire1[1])));
            tires.Add(new Tires(double.Parse(infoTire2[0]), int.Parse(infoTire2[1])));
            tires.Add(new Tires(double.Parse(infoTire3[0]), int.Parse(infoTire3[1])));
            tires.Add(new Tires(double.Parse(infoTire4[0]), int.Parse(infoTire4[1])));
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
