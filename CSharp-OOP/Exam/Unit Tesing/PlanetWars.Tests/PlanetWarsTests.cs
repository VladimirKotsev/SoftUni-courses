using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        private const string Name = "Planet";
        private const double Budget = 100;

        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void TestConstructor()
            {
                Planet planet = new Planet(Name, Budget);

                Assert.That(planet, Is.Not.Null);
            }

            [Test]
            public void TestGettersThroughConstructor()
            {
                var planet = new Planet(Name, Budget);

                Assert.AreEqual(planet.Name, Name);
                Assert.AreEqual(planet.Budget, Budget);
                CollectionAssert.AreEqual(planet.Weapons, new List<Weapon>());
            }

            [TestCase("")]
            [TestCase(null)]
            public void TestSetterOfName_Excetion(string parameter)
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(parameter, Budget);
                },
                "Invalid planet Name");
            }

            [TestCase (-1)]
            [TestCase (-5)]
            [TestCase (-10)]
            public void TestSetterOfBudget_Exception(double parameter)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(Name, parameter);
                },
                "Budget cannot drop below Zero!");
            }

            [Test]
            public void TestMilitaryPowerRatio()
            {
                var planet = new Planet(Name, Budget);

                var weapon1 = new Weapon("weapon1", 20, 23);
                var weapon2 = new Weapon("weapon2", 40, 25);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                var expected = weapon1.DestructionLevel + weapon2.DestructionLevel;

                Assert.AreEqual(expected, planet.MilitaryPowerRatio);
            }

            [Test]
            public void TestProfitMethod()
            {
                var planet = new Planet(Name, Budget);

                planet.Profit(15.5);

                Assert.AreEqual(Budget + 15.5, planet.Budget);
            }

            [Test]
            public void TestSpendFunds_Exception()
            {
                var planet = new Planet(Name, Budget);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(120);
                },
                $"Not enough funds to finalize the deal.");
            }

            [Test]
            public void TestSpendFunds_Successfull()
            {
                var planet = new Planet(Name, Budget);
                planet.SpendFunds(40);

                Assert.AreEqual(60, planet.Budget);
            }

            [Test]
            public void TestAddWeaponMethod_Exception()
            {
                var planet = new Planet(Name, Budget);

                var weapon1 = new Weapon("Hammer", 20, 23);
                
                planet.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon1);
                },
                $"There is already a Hammer weapon.");
            }

            [Test]
            public void TestAddWeaponMethod_Successfull()
            {
                var planet = new Planet(Name, Budget);

                var weapon1 = new Weapon("Hammer", 20, 23);
                planet.AddWeapon(weapon1);

                CollectionAssert.AreEqual(planet.Weapons, new List<Weapon>() { weapon1 });
                Assert.AreEqual(planet.Weapons.Count, 1);
            }

            [Test]
            public void TestRemoveWeaponMethod()
            {
                var planet = new Planet(Name, Budget);

                var weapon1 = new Weapon("Hammer", 20, 23);
                planet.AddWeapon(weapon1);
                planet.RemoveWeapon("Hammer");

                CollectionAssert.AreEqual(planet.Weapons, new List<Weapon>());
                Assert.AreEqual(planet.Weapons.Count, 0);
            }

            [Test]
            public void TestUpgradeWeaponMethod_Exception()
            {
                var planet = new Planet(Name, Budget);

                var weapon1 = new Weapon("Hammer", 20, 23);
                planet.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Axe");
                },
                $"Axe does not exist in the weapon repository of {Name}");
            }

            [Test]
            public void TestUpgradeMethod_Successfull()
            {
                var planet = new Planet(Name, Budget);

                var weapon1 = new Weapon("Hammer", 20, 23);
                planet.AddWeapon(weapon1);

                planet.UpgradeWeapon("Hammer");
                Assert.AreEqual(weapon1.DestructionLevel, 24);
                Assert.AreEqual(planet.Weapons.First(x => x.Name == "Hammer").DestructionLevel, 24);
            }

            [TestCase (23)]
            [TestCase (50)]
            [TestCase (100)]
            public void TestDestuctionMethod_Exception(int dmg)
            {
                var planet = new Planet(Name, Budget);

                var planetToBeAttacked = new Planet("Stronger", 100);

                var weapon1 = new Weapon("Hammer", 20, 23);
                var weapon2 = new Weapon("Axe", 20, dmg);

                planet.AddWeapon(weapon1);
                planetToBeAttacked.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planetToBeAttacked);
                },
                $"Stronger is too strong to declare war to!");
            }

            [TestCase (24)]
            [TestCase (50)]
            public void TestDestructionMethod_Successfull(int dmg)
            {
                var planet = new Planet(Name, Budget);

                var planetToBeAttacked = new Planet("Weaker", 100);

                var weapon1 = new Weapon("Hammer", 20, 23);
                var weapon2 = new Weapon("Axe", 20, dmg);

                planet.AddWeapon(weapon2);
                planetToBeAttacked.AddWeapon(weapon1);

                string result = planet.DestructOpponent(planetToBeAttacked);

                Assert.AreEqual(result, $"Weaker is destructed!");
            }
        }
    }
}
