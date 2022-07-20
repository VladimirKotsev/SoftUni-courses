namespace Shapes
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Shape rectangle = new Rectangle(5.25, 6.5);
                Shape cirle = new Circle(3.25);

                Console.WriteLine(rectangle.CalculateArea());
                Console.WriteLine(rectangle.CalculatePerimeter());

                Console.WriteLine(cirle.CalculateArea());
                Console.WriteLine(cirle.CalculatePerimeter());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
