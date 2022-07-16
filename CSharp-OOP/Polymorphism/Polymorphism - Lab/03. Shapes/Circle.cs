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
            private set { radius = value; }
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalculatePerimeter()
        {
            throw new NotImplementedException();
        }

        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }
}
