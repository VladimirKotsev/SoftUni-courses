using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "Golf";
            car.Year = 2025;
            car.FuelQuantity = 200;
            car.FuelConsumption = 10;
            car.Drive(200);
            Console.WriteLine(car.WhoAmI());

            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thridCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
        }
    }
}
