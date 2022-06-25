using System;
using System.Collections.Generic;
using System.Text;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private double rate;
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        private int days;
        public int Days
        {
            get { return days; }
            set { days = value; }
        }
        private bool hired;
        public bool Hired
        {
            get { return hired; }
            set { hired = value; }
        }

        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
            this.Hired = false;
        }

        public override string ToString()
        {
            return $"-Renovator: {this.Name}{Environment.NewLine}" +
                   $"--Speciality: {this.Type}{Environment.NewLine}" +
                   $"--Rate per day: {this.Rate} BGN";
        }
    }
}
