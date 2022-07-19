using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                    fuelQuantity = 0;
                else
                    fuelQuantity = value;
            }
        }

        private double fuelConsimption;
        public virtual double FuelConsumption
        {
            get
            {
                return fuelConsimption;
            }
            protected set
            {
                fuelConsimption = value;
            }
        }

        private double tankCapacity;

        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            protected set
            {
                tankCapacity = value;
            }
        }


        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public string Drive(double kilometers)
        {
            double burnedLitters = this.FuelConsumption * (double)kilometers;
            if (this.FuelQuantity >= burnedLitters)
            {
                this.FuelQuantity -= burnedLitters;
                return $"{this.GetType().Name} travelled {kilometers} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public string DriveFilledBus(double kilometers)
        {
            double burnedLitters = (this.FuelConsumption + 1.4) * (double)kilometers;
            if (this.FuelQuantity >= burnedLitters)
            {
                this.FuelQuantity -= burnedLitters;
                return $"{this.GetType().Name} travelled {kilometers} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refill(double litters)
        {
            if (litters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + litters > this.tankCapacity)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += litters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
