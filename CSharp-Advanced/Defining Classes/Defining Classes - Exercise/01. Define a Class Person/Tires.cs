using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tires
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private double pressure;

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
        public Tires(double tirePressure, int tireAge)
        {
            this.Pressure = tirePressure;
            this.Age = tireAge;
        }
    }
}
