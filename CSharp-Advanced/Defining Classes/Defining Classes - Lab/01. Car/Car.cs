using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelConsumption;
        private double fuelQuantity;

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public string WhoAmI()
        {
            return
                $"Make: {this.Make} Model: { this.Model} Year: { this.Year} Fuel: { this.FuelQuantity:F2}";
        }
        public void Drive(double distance)
        {
            if (this.FuelQuantity >= distance * this.FuelConsumption)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public Car()
        {

        }
        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
    }
}
