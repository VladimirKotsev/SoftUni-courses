namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Rectangle : Shape
    {
        private double height;
        public double Height
        {
            get { return height; }
            private set 
            {
                if (value < 0)
                    throw new ArgumentException("Invalid height");
                height = value; 
            }
        }

        private double width;
        public double Width
        {
            get { return width; }
            private set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Invalid width!");
                width = value; 
            }
        }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculatePerimeter()
        {
            return (2 * this.Width) + (2 * this.Height);
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }
        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }
    }
}
