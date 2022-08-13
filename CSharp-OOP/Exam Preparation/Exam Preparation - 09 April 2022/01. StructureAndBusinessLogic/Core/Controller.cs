namespace Formula1.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Utilities;


    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.carRepository = new FormulaOneCarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = pilotRepository.FindByName(fullName);
            if (pilot == null)
            {
                pilotRepository.Add(new Pilot(fullName));
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type == "Ferrari")
            {
                IFormulaOneCar car = carRepository.FindByName(model);
                if (car is null)
                {
                    carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
                }
                else
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
            }
            else if (type == "Williams")
            {
                IFormulaOneCar car = carRepository.FindByName(model);
                if (car is null)
                {
                    carRepository.Add(new Williams(model, horsepower, engineDisplacement));
                }
                else
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = raceRepository.FindByName(raceName);
            if (race is null)
            {
                raceRepository.Add(new Race(raceName, numberOfLaps));
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);

            if (pilot is null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = carRepository.FindByName(carModel);
            if (car is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return String.Format(
                OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race is null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (pilot is null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            if (race is null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            List<IPilot> winners = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();

            race.Pilots.First(x => x.FullName == winners[0].FullName).WinRace();

            return $"Pilot {winners[0].FullName} wins the {race.RaceName} race." + Environment.NewLine +
                   $"Pilot {winners[1].FullName} is second in the {race.RaceName} race." + Environment.NewLine +
                   $"Pilot {winners[2].FullName} is third in the {race.RaceName} race.";
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in raceRepository.Models.Where(x => x.TookPlace == true))
            {
                sb.AppendLine(pilot.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList())
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
