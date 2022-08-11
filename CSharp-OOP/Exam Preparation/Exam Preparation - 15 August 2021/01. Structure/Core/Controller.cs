namespace CarRacing.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Models.Cars;
    using Models.Cars.Contracts;
    using Models.Maps;
    using Models.Maps.Contracts;
    using Models.Racers;
    using Models.Racers.Contracts;
    using Utilities.Messages;
    using Repositories;
    using Contracts;

    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        { 
            if (type == "SuperCar")
            {
                ICar superCar = new SuperCar(make, model, VIN, horsePower);
                cars.Add(superCar);
            }
            else if (type == "TunedCar")
            {
                ICar tunedCar = new TunedCar(make, model, VIN, horsePower);
                cars.Add(tunedCar);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == "ProfessionalRacer")
            {
                IRacer racer = new ProfessionalRacer(username, car);
                racers.Add(racer);
            }
            else if (type == "StreetRacer")
            {
                IRacer racer = new StreetRacer(username, car);
                racers.Add(racer);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);

        }

        public string Report()
        {
            return racers.ToString();
        }
    }
}
