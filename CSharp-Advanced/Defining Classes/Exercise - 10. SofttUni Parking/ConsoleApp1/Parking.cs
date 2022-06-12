using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;

        private List<Car> cars;
        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }
        public int Count { get; set; }

        public Parking(int n)
        {
            this.Cars = new List<Car>();
            this.capacity = n;
        }

        private bool CheckIfExists(Car car)
        {
            string number = car.RegistrationNumber;
            foreach (Car c in cars)
            {
                if (c.RegistrationNumber == number)
                    return true;
            }
            return false;
        }
        private bool CheckForCapacity()
        {
            if (this.Cars.Count + 1 > capacity)
                return true;
            return false;
        }
        private bool CheckIfExists2(List<Car> cars, string regNumber)
        {
            string registration = regNumber;
            foreach (Car c in cars)
            {
                if (c.RegistrationNumber == registration)
                    return true;
            }
            return false;
        }

        public string AddCar(Car car)
        {
            bool isExistring = CheckIfExists(car); //true -> message
            bool isFull = CheckForCapacity(); //true -> message

            if (!isExistring && !isFull)
            {
                this.Cars.Add(car);
                this.Count++;
                return $"Succesfully added new car {car.Make} {car.RegistrationNumber}";
            }
            else if (isExistring)
                return $"Car with that registration number, already exists!";
            else if (isFull)
                return "Parking is full!"; ;
            throw new ArgumentException("Invalid AddCar command");
        }
        public string RemoveCar(string registrationNumber)
        {
            bool isExisting = CheckIfExists2(this.Cars, registrationNumber); //true -> existing
            if (isExisting)
            {
                this.Cars.Remove(this.Cars.Find(x => x.RegistrationNumber == registrationNumber));
                this.Count--;
                return $"Succesfully removed {registrationNumber}";

            }
            else
                return "Car with that registration number, doesn't exist!";
        }
        public Car GetCar(string registrationNumber)
        {
            return this.Cars.Find(x => x.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (string reg in RegistrationNumbers)
            {
                //this.Cars.Remove(this.Cars.Find(x => x.RegistrationNumber == reg));
                int count = this.Cars.Count;
                for (int i = 0; i < count; i++)
                {
                    if (this.Cars[i].RegistrationNumber == reg)
                    {
                        this.Cars.RemoveAt(i);
                        this.Count--;
                        break;
                    }
                }
            }
        }

    }
}
