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

            //04. Opinion Poll]
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
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            Car car = new Car();
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Car newCar = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
                cars.Add(newCar);
            }
            var info = Console.ReadLine().Split(' ');
            while (info[0] != "End")
            {
                car.Drive(cars, info[1], int.Parse(info[2]));
                info = Console.ReadLine().Split(' ');
            }
            PrintOut(cars);
        }
        //06. Speed Racing
        static void PrintOut(List<Car> cars)
        {
            foreach(Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
