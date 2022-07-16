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
            private set { height = value; }
        }

        private double width;
        public double Width
        {
            get { return width; }
            private set { width = value; }
        }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
    }
}
