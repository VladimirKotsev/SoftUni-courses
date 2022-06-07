using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //03. Oldest Family Member
            //int n = int.Parse(Console.ReadLine());
            //Family family = new Family();
            //for (int i = 1; i <= n; i++)
            //{
            //    string input = Console.ReadLine();
            //    Person person = new Person(input.Split(' ')[0], int.Parse(input.Split(' ')[1]));
            //    family.AddMember(person);
            //}
            //Console.WriteLine(family.GetOldestMember().Name + ' ' + family.GetOldestMember().Age);

            //04. Opinion Poll
            //int n = int.Parse(Console.ReadLine());
            //List<Person> people = new List<Person>();
            //for (int i = 1; i <= n; i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ');
            //    Person person = new Person(input[0], int.Parse(input[1]));
            //    people.Add(person);
            //}
            //people.RemoveAll(x => x.Age == 0);
            //foreach(var person in people.OrderBy(x => x.Name))
            //{
            //    Console.WriteLine($"{person.Name} - {person.Age}");
            //}

            //06. Speed Racing
            //int n = int.Parse(Console.ReadLine());
            //List<Car> cars = new List<Car>();
            //Car car = new Car();
            //for (int i = 1; i <= n; i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ');
            //    Car newCar = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
            //    cars.Add(newCar);
            //}
            //var info = Console.ReadLine().Split(' ');
            //while (info[0] != "End")
            //{
            //    car.Drive(cars, info[1], int.Parse(info[2]));
            //    info = Console.ReadLine().Split(' ');
            //}
            //PrintOut(cars);

            //07. Raw Data
            //int n = int.Parse(Console.ReadLine());
            //List<Car> cars = new List<Car>();
            //for (int i = 1; i <= n; i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ');
            //    string model = input[0];
            //    int speed = int.Parse(input[1]);
            //    int power = int.Parse(input[2]);
            //    int weight = int.Parse(input[3]);
            //    string type = input[4];
            //    List<string> infoTire1 = new List<string>()
            //    {
            //        input[5], //pressure
            //        input[6] //age
            //    };
            //    List<string> infoTire2 = new List<string>()
            //    {
            //        input[7], //pressure
            //        input[8] //age
            //    };
            //    List<string> infoTire3 = new List<string>()
            //    {
            //        input[9], //pressure
            //        input[10] //age
            //    };
            //    List<string> infoTire4 = new List<string>()
            //    {
            //        input[11], //pressure
            //        input[12]  //age
            //    };
            //    Car newCar = new Car(model, speed, power, weight, type, infoTire1, infoTire2, infoTire3, infoTire4);
            //    cars.Add(newCar);
            //}

            //string cmd = Console.ReadLine();
            //switch(cmd)
            //{
            //    case "fragile":
            //        PrintOutFragile(cars);
            //        break;
            //    case "flammable":
            //        PrintOutFlammable(cars);
            //        break;
            //}

            //08. Car Salesman
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            Car car1 = new Car();
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int power = int.Parse(input[1]);
                if (input.Length == 2)
                {
                    Engine newEngine = new Engine(input[0], power);
                    engines.Add(newEngine);
                }
                else if (input.Length == 3 && int.TryParse(input[2], out int number))
                {
                    Engine newEngine = new Engine(input[0], power, number);
                    engines.Add(newEngine);
                }
                else if (input.Length == 3 && !int.TryParse(input[2], out int number1))
                {
                    Engine newEngine = new Engine(input[0], power, input[2]);
                    engines.Add(newEngine);
                }
                else if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string eff = input[3];
                    Engine newEngine = new Engine(input[0], power, displacement, eff);
                    engines.Add(newEngine);
                }
            }
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 2)
                {
                    Car car = new Car(input[0], input[1], engines);
                    cars.Add(car);
                }
                else if (input.Length == 3 && int.TryParse(input[2], out int number))
                {
                    Car car = new Car(input[0], input[1], number, engines);
                    cars.Add(car);
                }
                else if (input.Length == 3 && !int.TryParse(input[2], out int number1))
                {
                    Car car = new Car(input[0], input[1], input[2], engines);
                    cars.Add(car);
                }
                else if (input.Length == 4)
                {
                    Car car = new Car(input[0], input[1], int.Parse(input[2]), input[3], engines);
                    cars.Add(car);
                }
            }
            car1.ListCars(cars);

        }
        //06. Speed Racing
        //static void PrintOut(List<Car> cars)
        //{
        //    foreach(Car car in cars)
        //    {
        //        Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        //    }
        //}

        //07. Raw Data
        //static void PrintOutFragile(List<Car> cars)
        //{
        //    List<Car> filtered = cars.Where(x => x.cargo.Type == "fragile").ToList();
        //    foreach (var car in filtered)
        //    {
        //        if (car.tires.Any(x => x.Pressure < 1))
        //            Console.WriteLine(car.Model);
        //    }
        //}
        //static void PrintOutFlammable(List<Car> cars)
        //{
        //    List<Car> filtered = cars.Where(x => x.cargo.Type == "flammable").ToList();
        //    foreach (var car in filtered)
        //    {
        //        if (car.engine.Power > 250)
        //            Console.WriteLine(car.Model);
        //    }
        //}

    }
}
