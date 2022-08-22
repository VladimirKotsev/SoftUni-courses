namespace PlanetWars.Core
{
    using System.Linq;

    using Contracts;
    using PlanetWars.Repositories;
    using Models.Planets.Contracts;
    using Utilities.Messages;
    using System;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.Weapons;
    using System.Text;

    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = this.planets.FindByName(name);

            if (planet is null)
            {
                planet = new Planet(name, budget);
                this.planets.AddItem(planet);
                return String.Format(OutputMessages.NewPlanet, name);
            }
            else
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet is null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName == "AnonymousImpactUnit")
            {
                if (planet.Army.Any(x => x.GetType().Name.Contains("AnonymousImpactUnit")))
                {
                    throw new InvalidOperationException(
                        String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }

                IMilitaryUnit unit = new AnonymousImpactUnit();
                planet.Spend(unit.Cost);

                planet.AddUnit(unit);

                return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            }
            else if (unitTypeName == "SpaceForces")
            {
                if (planet.Army.Any(x => x.GetType().Name.Contains("SpaceForces")))
                {
                    throw new InvalidOperationException(
                        String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }

                IMilitaryUnit unit = new SpaceForces();
                planet.Spend(unit.Cost);

                planet.AddUnit(unit);

                return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

            }
            else if (unitTypeName == "StormTroopers")
            {
                if (planet.Army.Any(x => x.GetType().Name.Contains("StormTroopers")))
                {
                    throw new InvalidOperationException(
                        String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }

                IMilitaryUnit unit = new StormTroopers();
                planet.Spend(unit.Cost);

                planet.AddUnit(unit);

                return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            }
            else
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet is null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName == "BioChemicalWeapon")
            {
                if (planet.Army.Any(x => x.GetType().Name.Contains("BioChemicalWeapon")))
                {
                    throw new InvalidOperationException(
                        String.Format(
                            ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }

                IWeapon weapon = new BioChemicalWeapon(destructionLevel);
                planet.Spend(weapon.Price);

                planet.AddWeapon(weapon);

                return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                if (planet.Army.Any(x => x.GetType().Name.Contains("NuclearWeapon")))
                {
                    throw new InvalidOperationException(
                        String.Format(
                            ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }

                IWeapon weapon = new NuclearWeapon(destructionLevel);
                planet.Spend(weapon.Price);

                planet.AddWeapon(weapon);

                return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                if (planet.Army.Any(x => x.GetType().Name.Contains("SpaceMissiles")))
                {
                    throw new InvalidOperationException(
                        String.Format(
                            ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }

                IWeapon weapon = new SpaceMissiles(destructionLevel);
                planet.Spend(weapon.Price);

                planet.AddWeapon(weapon);

                return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
            }
            else
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet is null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);

            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attacker = this.planets.FindByName(planetOne);
            IPlanet defender = this.planets.FindByName(planetTwo);

            if (attacker.MilitaryPower == defender.MilitaryPower)
            {
                if (!attacker.Weapons.GetType().Name.Contains("NuclearWeapon") &&
                    !defender.Weapons.GetType().Name.Contains("NuclearWeapon") ||
                     attacker.Weapons.GetType().Name.Contains("NuclearWeapon") &&
                     defender.Weapons.GetType().Name.Contains("NuclearWeapon"))
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);
                    return OutputMessages.NoWinner;

                }

                if (attacker.Weapons.GetType().Name.Contains("NuclearWeapon") &&
                    !defender.Weapons.GetType().Name.Contains("NuclearWeapon"))
                {
                    double profit = 0;
                    attacker.Spend(attacker.Budget / 2);

                    profit += defender.Budget / 2;
                    profit += defender.Army.Sum(x => x.Cost);
                    profit += defender.Weapons.Sum(x => x.Price);

                    this.planets.RemoveItem(defender.Name);
                    attacker.Profit(profit);

                    return String.Format(OutputMessages.WinnigTheWar, attacker.Name, defender.Name);
                }
                else
                {
                    double profit = 0;
                    defender.Spend(defender.Budget / 2);

                    profit += attacker.Budget / 2;
                    profit += attacker.Army.Sum(x => x.Cost);
                    profit += attacker.Weapons.Sum(x => x.Price);

                    this.planets.RemoveItem(attacker.Name);
                    defender.Profit(profit);

                    return String.Format(OutputMessages.WinnigTheWar, defender.Name, attacker.Name);
                }
            }
            else if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                double profit = 0;
                attacker.Spend(attacker.Budget / 2);

                profit += defender.Budget / 2;
                profit += defender.Army.Sum(x => x.Cost);
                profit += defender.Weapons.Sum(x => x.Price);

                this.planets.RemoveItem(defender.Name);
                attacker.Profit(profit);

                return String.Format(OutputMessages.WinnigTheWar, attacker.Name, defender.Name);
            }
            else
            {
                double profit = 0;
                defender.Spend(defender.Budget / 2);

                profit += attacker.Budget / 2;
                profit += attacker.Army.Sum(x => x.Cost);
                profit += attacker.Weapons.Sum(x => x.Price);

                this.planets.RemoveItem(attacker.Name);
                defender.Profit(profit);

                return String.Format(OutputMessages.WinnigTheWar, defender.Name, attacker.Name);
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("***UNIVERSE PLANET MILITARY REPORT***" + Environment.NewLine);

            foreach(var planet in this.planets.Models)
            {
                sb.Append(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
