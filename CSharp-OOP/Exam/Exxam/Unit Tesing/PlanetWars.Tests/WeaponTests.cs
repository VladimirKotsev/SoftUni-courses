namespace PlanetWars.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WeaponTests
    {
        [Test]
        public void TestConstructor()
        {
            Weapon weapon = new Weapon("Axe", 20, 50);
            Assert.IsNotNull(weapon);
        }

        [Test]
        public void TestGetters()
        {
            Weapon weapon = new Weapon("Axe", 20, 50);

            Assert.AreEqual(weapon.Name, "Axe");
            Assert.AreEqual(weapon.Price, 20);
            Assert.AreEqual(weapon.DestructionLevel, 50);
        }

        [TestCase (-1)]
        [TestCase (-5)]
        public void TestSetterPrice(double price)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Weapon weapon = new Weapon("Axe", price, 50);
            },
            "Price cannot be negative.");
        }

        [Test]
        public void TestGetterOfIsNuclear()
        {
            Weapon weapon = new Weapon("Axe", 20, 50);

            Assert.AreEqual(true, weapon.IsNuclear);
        }

        [Test]
        public void TestGetterOfIsNuclear2()
        {
            Weapon weapon = new Weapon("Axe", 20, 5);

            Assert.AreEqual(false, weapon.IsNuclear);
        }
    }
}
