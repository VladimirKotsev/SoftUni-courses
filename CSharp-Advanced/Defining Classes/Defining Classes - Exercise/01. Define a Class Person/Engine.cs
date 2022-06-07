using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private int power;
        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        private int displacement;
        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        private string efficiency;
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }


        private int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
    }
}
