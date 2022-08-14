namespace PlanetWars.Models.Planets
{
    using System;

    using Utilities.Messages;
    using Repositories;
    using Contracts;
    using System.Collections.Generic;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using System.Linq;

    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        private double budget;
        public double Budget
        {
            get { return budget; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower
        {
            get { return CalculateMilitaryPower(); }
        }

        private double CalculateMilitaryPower()
        {
            double totalAmount = 
                this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);

            if (this.units.Models.Any(x => x.GetType().Name.Contains("AnonymousImpactUnit")))
            {
                totalAmount *= 1.30;
            }
            else if (this.weapons.Models.Any(x => x.GetType().Name.Contains("NuclearWeapon")))
            {
                totalAmount *= 1.45;
            }

            return Math.Round(totalAmount, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get { return units.Models; }
        }

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get { return weapons.Models; }
        }

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.weapons = new WeaponRepository();
            this.units = new UnitRepository();
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in this.units.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public string PlanetInfo()
        {
            if (this.weapons.Models.Count == 0 && this.units.Models.Count > 0)
            {
                return $"Planet: {this.Name}" + Environment.NewLine +
                       $"--Budget: {this.Budget} billion QUID" + Environment.NewLine +
                       $"--Forces: {String.Join(", ", this.units.Models.Select(x => x.GetType().Name))}" + Environment.NewLine +
                       $"--Combat equipment: No weapons" + Environment.NewLine +
                       $"--Military Power: {this.MilitaryPower}" + Environment.NewLine;           
            }
            else if (this.weapons.Models.Count > 0 && this.units.Models.Count == 0)
            {
                return $"Planet: {this.Name}" + Environment.NewLine +
                       $"--Budget: {this.Budget} billion QUID" + Environment.NewLine +
                       $"--Forces: No units" + Environment.NewLine +
                       $"--Combat equipment: {String.Join(", ", this.weapons.Models.Select(x => x.GetType().Name))}" + Environment.NewLine +
                       $"--Military Power: {this.MilitaryPower}" + Environment.NewLine;
            }
            else if (this.weapons.Models.Count == 0 && this.units.Models.Count == 0)
            {
                return $"Planet: {this.Name}" + Environment.NewLine +
                       $"--Budget: {this.Budget} billion QUID" + Environment.NewLine +
                       $"--Forces: No units" + Environment.NewLine +
                       $"--Combat equipment: No weapons" + Environment.NewLine +
                       $"--Military Power: {this.MilitaryPower}" + Environment.NewLine;
            }
            else
            {
                return $"Planet: {this.Name}" + Environment.NewLine +
                       $"--Budget: {this.Budget} billion QUID" + Environment.NewLine +
                       $"--Forces: {String.Join(", ", this.units.Models.Select(x => x.GetType().Name))}" + Environment.NewLine +
                       $"--Combat equipment: {String.Join(", ", this.weapons.Models.Select(x => x.GetType().Name))}" + Environment.NewLine +
                       $"--Military Power: {this.MilitaryPower}" + Environment.NewLine;
            }
        }
    }
}
