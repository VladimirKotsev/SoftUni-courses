
namespace _01._Class_Box_Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Box
    {
        public const string ArgumentMessage = "{0} cannot be zero or negative.";

        private double length;
        public double Length
        {
            get { return length; }
            private set 
            {
                if (value <= 0)
                    throw new ArgumentException
                        (String.Format(ArgumentMessage, nameof(this.Length)));
                length = value; 
            }
        }
        private double width;
        public double Width
        {
            get { return width; }
            private set 
            {
                if (value <= 0)
                    throw new ArgumentException
                        (String.Format(ArgumentMessage, nameof(this.Width)));
                width = value; 
            }
        }
        private double height;
        public double Height
        {
            get { return height; }
            private set 
            { 
                if (value <= 0)
                    throw new ArgumentException
                        (String.Format(ArgumentMessage, nameof(this.Height)));
                height = value; 
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double SurfaceArea()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) +
            (2 * this.Width * this.Height);
        }
        public double LateralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea():f2}\n" +
                   $"Lateral Surface Area - {this.LateralSurfaceArea():f2}\n" +
                   $"Volume - {this.Volume():f2}";
        }
    }
}
