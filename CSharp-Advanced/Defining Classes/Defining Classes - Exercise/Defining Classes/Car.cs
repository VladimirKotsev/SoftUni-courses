using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public List<Tires> tires = new List<Tires>();
        public Cargo cargo;
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private int weight;
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
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
        public Car(string model, string engineName, List<Engine> engines)
        {
            this.model = model;
            this.Engine = engines.Find(x => x.Model == engineName);
        }
        public Car(string model, string engineName, string color, List<Engine> engines)
        {
            this.model = model;
            this.Engine = engines.Find(x => x.Model == engineName);
            this.Color = color;
        }
        public Car(string model, string engineName, int weight, List<Engine> engines)
        {
            this.model = model;
            this.Engine = engines.Find(x => x.Model == engineName);
            this.Weight = weight;
        }
        public Car(string model, string engineName, int weight, string color, List<Engine> engines)
        {
            this.model = model;
            this.Engine = engines.Find(x => x.Model == engineName);
            this.Weight = weight;
            this.Color = color;
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

        public void ListCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model + ":");
                Console.WriteLine("  " + car.Engine.Model + ":");
                Console.WriteLine("    Power: " + car.Engine.Power);

                if (car.Engine.Displacement == 0)
                    Console.WriteLine("    Displacement: n/a");
                else
                    Console.WriteLine("    Displacement: " + car.Engine.Displacement);

                if (car.Engine.Efficiency == null)
                    Console.WriteLine("    Efficiency: n/a");
                else
                    Console.WriteLine("    Efficiency: " + car.Engine.Efficiency);

                if (car.Weight == 0)
                    Console.WriteLine("  Weight: n/a");
                else
                    Console.WriteLine("  Weight: " + car.Weight);

                if (car.Color == null)
                    Console.WriteLine("  Color: n/a");
                else
                    Console.WriteLine("  Color: " + car.Color);
            }
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
