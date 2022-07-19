namespace _01._Vehicles
{
    using Core.Intefaces;
    using Models;
    using System;
    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;

        public Engine(Vehicle car, Vehicle truck, Vehicle bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void Start()
        {
            int numberOfLine = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLine; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (line[0] == "Drive")
                {
                    switch (line[1])
                    {
                        case "Car":
                            Console.WriteLine(car.Drive(double.Parse(line[2])));
                            break;
                        case "Truck":
                            Console.WriteLine(truck.Drive(double.Parse(line[2])));
                            break;
                        case "Bus":
                            Console.WriteLine(bus.DriveFilledBus(double.Parse(line[2])));
                            break;
                    }
                }
                else if (line[0] == "DriveEmpty")
                {
                    Console.WriteLine(bus.Drive(double.Parse(line[2])));
                }
                else if (line[0] == "Refuel")
                {
                    switch (line[1])
                    {
                        case "Car":
                            car.Refill(double.Parse(line[2]));
                            break;
                        case "Truck":
                            truck.Refill(double.Parse(line[2]));
                            break;
                        case "Bus":
                            bus.Refill(double.Parse(line[2]));
                            break;
                    }
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}
