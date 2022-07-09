namespace Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Seat : ICar
    {
        private string model;
        public string Model { get => this.model; set => model = value; }
        private string color;
        public string Color { get => this.color; set => color = value; }

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
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
            return $"{this.Color} Seat {this.Model}{Environment.NewLine}" +
                   $"Engine start{Environment.NewLine}" + 
                   this.Start();
        }
    }
}
