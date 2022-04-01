using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
        public Vehicle(string type, string model, string color, double hp)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = hp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Vehicle> vehicleCatalogue = new List<Vehicle>();
            while (input != "End")
            {
                string[] array = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Vehicle newVehicle = new Vehicle(array[0], array[1], array[2], double.Parse(array[3]));
                vehicleCatalogue.Add(newVehicle);
                input = Console.ReadLine();
            }
            string input2 = Console.ReadLine();
            while (input2 != "Close the Catalogue")
            {
                int indexToPrint = vehicleCatalogue.FindIndex(x => x.Model == input2);

                PrintInfo(vehicleCatalogue, indexToPrint);

                input2 = Console.ReadLine();
            }
            double sumCar = 0;
            int countCar = 0;
            double sumTruck = 0;
            int countTruck = 0;
            //List<double> HPCar = new List<double>();
            //List<double> HPTruck = new List<double>();
            for (int i = 0; i < vehicleCatalogue.Count; i++)
            {
                if (vehicleCatalogue[i].Type == "car")
                {
                    sumCar += vehicleCatalogue[i].HorsePower;
                    countCar++;
                    //HPCar.Add(vehicleCatalogue[i].HorsePower);
                }
                else if (vehicleCatalogue[i].Type == "truck")
                {
                    sumTruck += vehicleCatalogue[i].HorsePower;
                    countTruck++;
                    //HPTruck.Add(vehicleCatalogue[i].HorsePower);
                }
            }
            if (sumCar > 0 && sumTruck > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {sumCar/(double)countCar:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {sumTruck/(double)countTruck:f2}.");
            }
            else if (sumCar == 0 && sumTruck == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
            else if (sumCar == 0 && sumTruck > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {sumTruck/(double)countTruck:f2}.");
            }
            else if (sumTruck == 0 && sumCar > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {sumCar/(double)countCar:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }

        }
        static void PrintInfo(List<Vehicle> list, int index)
        {

            Console.WriteLine($"Type: {char.ToUpper(list[index].Type[0]) + list[index].Type.Substring(1)}");
            Console.WriteLine($"Model: {list[index].Model}");
            Console.WriteLine($"Color: {list[index].Color}");
            Console.WriteLine($"Horsepower: {list[index].HorsePower}");

        }
    }
}
