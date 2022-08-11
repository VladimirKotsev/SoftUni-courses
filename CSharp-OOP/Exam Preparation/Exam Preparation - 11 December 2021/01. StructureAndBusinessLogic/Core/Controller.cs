namespace Gym.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Equipment;
    using Models.Athletes;
    using Models.Athletes.Contracts;
    using Utilities.Messages;
    using Models.Gyms;
    using Models.Gyms.Contracts;
    using Repositories;
    using Models.Equipment.Contracts;

    internal class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                IGym boxGym = new BoxingGym(gymName);
                gyms.Add(boxGym);
            }
            else if (gymType == "WeightliftingGym")
            {
                IGym weightGym = new WeightliftingGym(gymName);
                gyms.Add(weightGym);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }
        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                IEquipment newEquipment = new BoxingGloves();
                this.equipment.Add(newEquipment);
            }
            else if (equipmentType == "Kettlebell")
            {
                IEquipment newEquipment = new Kettlebell();
                this.equipment.Add(newEquipment);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment newEquipment = equipment.Models
                .FirstOrDefault(x => x.GetType().Name == equipmentType);

            if (newEquipment == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            IGym gym = gyms.First(x => x.Name == gymName);

            gym.AddEquipment(newEquipment);
            equipment.Remove(newEquipment);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType == "Boxer")
            {
                IGym gym = gyms.First(x => x.Name == gymName);

                if (gym.GetType().Name != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }

                IAthlete athlete = new Boxer(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);
            }
            else if (athleteType == "Weightlifter")
            {
                IGym gym = gyms.First(x => x.Name == gymName);

                if (gym.GetType().Name != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }

                IAthlete athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }
        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.First(x => x.Name == gymName);
            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }

            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.First(x => x.Name == gymName);
            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }


        public string Report()
        {
            return String.Join(Environment.NewLine, gyms.Select(x => x.GymInfo()));
        }
    }
}
