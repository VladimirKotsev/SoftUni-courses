namespace Gym.Models.Gyms
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Equipment.Contracts;
    using Athletes.Contracts;

    public abstract class Gym : IGym
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public double EquipmentWeight
        {
            get
            {
                return this.equipment.Sum(x => x.Weight);
            }
        }
        private List<IEquipment> equipment;
        public ICollection<IEquipment> Equipment 
        {
            get
            {
                return this.equipment.AsReadOnly();
            }
        }

        private List<IAthlete> athletes;
        public ICollection<IAthlete> Athletes 
        {
            get
            {
                return this.athletes.AsReadOnly();
            }
        }

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            if (this.Athletes.Count > 0)
            {
                return $"{this.Name} is a {this.GetType().Name}:" + Environment.NewLine +
                       $"Athletes: {String.Join(", ", this.Athletes.Select(x => x.FullName))}" + Environment.NewLine +
                       $"Equipment total count: {this.Equipment.Count}" + Environment.NewLine +
                       $"Equipment total weight: {this.EquipmentWeight:F2} grams";
            }
            else
            {
                return $"{this.Name} is a {this.GetType().Name}:" + Environment.NewLine +
                       $"Athletes: No athletes" + Environment.NewLine +
                       $"Equipment total count: {this.Equipment.Count}" + Environment.NewLine +
                       $"Equipment total weight: {this.EquipmentWeight:F2} grams";
            }


        }

    }
}
