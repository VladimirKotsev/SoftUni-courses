namespace Heroes.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Repositories;
    using Contracts;
    using Models.Contracts;
    using Models.Heroes;
    using Models.Weapons;
    using Models.Map;

    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (type == "Knight")
            {
                IHero hero = heroes.FindByName(name);
                if (hero is null)
                {
                    heroes.Add(new Knight(name, health, armour));
                    return $"Successfully added Sir {name} to the collection.";
                }

                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            else if (type == "Barbarian")
            {
                IHero hero = heroes.FindByName(name);
                if (hero is null)
                {
                    heroes.Add(new Barbarian(name, health, armour));
                    return $"Successfully added Barbarian {name} to the collection.";
                }

                throw new InvalidOperationException(
                    $"The hero {name} already exists.");
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (type == "Claymore")
            {
                IWeapon weapon = weapons.FindByName(name);
                if (weapon is null)
                {
                    weapons.Add(new Claymore(name, durability));
                }
                else
                {
                    throw new InvalidOperationException($"The weapon {name} already exists.");
                }

            }
            else if (type == "Mace")
            {
                IWeapon weapon = weapons.FindByName(name);
                if (weapon is null)
                {
                    weapons.Add(new Mace(name, durability));
                }
                else
                {
                    throw new InvalidOperationException($"The weapon {name} already exists.");
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IWeapon weapon = weapons.FindByName(weaponName);
            IHero hero = heroes.FindByName(heroName);

            if (hero is null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            else if (weapon is null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            else if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            else
            {
                hero.AddWeapon(weapon);
                this.weapons.Remove(weapon);

                return
                    $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
            }
        }

        public string StartBattle()
        {
            IMap map = new Map();

            return
                map.Fight(this.heroes.Models
                .Where(x => x.IsAlive)
                .Where(t => t.Weapon != null)
                .ToList());
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes.Models
                .OrderBy(x => x.Name)
                .ThenByDescending(t => t.Health)
                .ThenBy(z => z.Name))
            {
                if (hero.Weapon is null)
                {
                    sb.Append(
                           $"{hero.GetType().Name}: {hero.Name}" + Environment.NewLine +
                           $"--Health: {hero.Health}" + Environment.NewLine +
                           $"--Armour: {hero.Armour}" + Environment.NewLine +
                           $"--Weapon: Unarmed" + Environment.NewLine);
                }
                else
                {
                    sb.Append(
                           $"{hero.GetType().Name}: {hero.Name}" + Environment.NewLine +
                           $"--Health: {hero.Health}" + Environment.NewLine +
                           $"--Armour: {hero.Armour}" + Environment.NewLine +
                           $"--Weapon: {hero.Weapon.Name}" + Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
