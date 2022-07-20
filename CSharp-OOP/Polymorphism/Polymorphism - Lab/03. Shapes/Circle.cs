namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid radius!");
                }
                radius = value; 
            }
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }
        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }
    }
}
