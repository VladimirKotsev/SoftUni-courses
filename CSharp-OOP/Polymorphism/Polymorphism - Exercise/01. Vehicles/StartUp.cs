namespace _01._Vehicles
{
    using System;
    using Core;
    using Models;
    using Core.Intefaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory.CreateFactory(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicle truck = vehicleFactory.CreateFactory(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Vehicle bus = vehicleFactory.CreateFactory(busInfo[0], double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            IEngine engine = new Engine(car, truck, bus);
            engine.Start();

        }
    }
}
