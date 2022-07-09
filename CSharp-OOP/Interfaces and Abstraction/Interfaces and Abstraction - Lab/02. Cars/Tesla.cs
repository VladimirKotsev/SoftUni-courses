namespace Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Tesla : IElectricCar, ICar
    {
        public int Battery { get => this.Battery; set => Battery = value; }
        public string Model { get => this.Model; set => Model = value; }
        public string Color { get => this.Color; set => Color = value; }

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Start()
        {
            return "Breaaak!";
        }

        public string Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries{Environment.NewLine}" +
                   $"Engine start{Environment.NewLine}" +
                   this.Start();
        }
    }
}
