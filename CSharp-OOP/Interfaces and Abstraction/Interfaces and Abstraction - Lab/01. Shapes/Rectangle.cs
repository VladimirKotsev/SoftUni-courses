namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Rectangle : IDrawable
    {
        private int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; i++)
                Console.Write(mid);
            Console.WriteLine(end);
        }

        public void Draw()
        {
            DrawLine(this.Width, '*', '*');

            for (int i = 1; i < this.Height - 1; i++)
                DrawLine(this.Width, '*', ' ');
            DrawLine(this.Width, '*', '*');
        }
    }
}
