namespace FightingArena.Tests
{
    using System;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestConstructorForSettingValidValues()
        {
            //Arrange
            string name = "Gosho";
            int damage = 20;
            int health = 100;

            string expectedName = name;
            int expectedDamage = damage;
            int expectedHealth = health;

            //Act
            Warrior warrior = new Warrior(name, damage, health);

            Type type = warrior.GetType();

            FieldInfo nameInfo = type.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);
            string actualName = (string)nameInfo.GetValue(warrior);

            FieldInfo damageInfo = type.GetField("damage", BindingFlags.NonPublic | BindingFlags.Instance);
            int actualDamage = (int)damageInfo.GetValue(warrior);

            FieldInfo hpInfo = type.GetField("hp", BindingFlags.NonPublic | BindingFlags.Instance);
            int actualHp = (int)hpInfo.GetValue(warrior);

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHealth, actualHp);
        }

        [TestCase ("")]
        [TestCase (" ")]
        public void TestInvalidName_ThrowingException(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                Warrior warrior = new Warrior(name, 20, 100);
            },
            //Assert
            "Name should not be empty or whitespace!");
        }

        [TestCase (-10)]
        [TestCase (0)]
        public void TestInvalidDamage_ThrowingException(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                Warrior warrior = new Warrior("Pesho", damage, 100);
            },
            //Assert
            "Damage value should be positive!");
        }

        [TestCase (-50)]
        [TestCase (-1)]
        public void TestInvalidHP_ThrowingException(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                Warrior warrior = new Warrior("Pesho", 20, hp);
            },
            //Assert
            "HP should not be negative!");
        }

        [Test]
        public void TestPropertyGetters()
        {
            //Arrange
            string name = "Gosho";
            int damage = 20;
            int health = 100;

            string expectedName = name;
            int expectedDamage = damage;
            int expectedHealth = health;

            //Act
            Warrior warrior = new Warrior(name, damage, health);

            //Assert
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHealth, warrior.HP);
        }

        [TestCase (199)]
        [TestCase (100)]
        [TestCase (10)]
        public void TestAttackMethod_ValidParameters(int dmg)
        {
            //Arrange
            Warrior attacker = new Warrior("Gosho", dmg, 100);
            Warrior defender = new Warrior("Pesho", 50, 200);

            int expectedHP = 200 - dmg;
            //Act
            defender.Attack(attacker);
            
            //Assert
            Assert.AreEqual(expectedHP, defender.HP);
        }

        [TestCase (18)]
        [TestCase(30)]
        [TestCase(1)]
        public void TestAttackMethodWithInvalidAttackerHP_ThrowingException(int hp)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Warrior attacker = new Warrior("Gosho", 60, hp);
                Warrior defender = new Warrior("Pesho", 50, 200);

                //Act
                defender.Attack(attacker);
            },
            //Assert
            "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(18)]
        [TestCase(30)]
        [TestCase(1)]
        public void TestAttackMethodInvalidDefenderHP_ThrowingException(int hp)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Warrior attacker = new Warrior("Gosho", 60, 100);
                Warrior defender = new Warrior("Pesho", 50, hp);

                //Act
                defender.Attack(attacker);
            },
            //Assert
            $"Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void TestAttackMethodWhenDefenderHasLowerHp_ThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Warrior attacker = new Warrior("Gosho", 200, 100);
                Warrior defender = new Warrior("Pesho", 50, 100);

                //Act
                defender.Attack(attacker);
            },
            //Assert
            $"You are trying to attack too strong enemy");
        }
    }
}