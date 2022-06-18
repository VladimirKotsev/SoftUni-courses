using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Racer
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = car;
        }

        public override string ToString()
        {
            return $"Racer: {this.Name}, {this.Age} ({this.Country})";
        }
    }
}
