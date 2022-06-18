using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Car
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Car(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;
        }

    }
}
