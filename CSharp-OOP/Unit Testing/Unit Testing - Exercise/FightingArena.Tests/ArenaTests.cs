namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void TestConstructorForInicializingNewCollection()
        {
            //Arrance && Act
            var arena = new Arena();

            List<Warrior> expectedCollection = new List<Warrior>();
            List<Warrior> actualCollection = arena.Warriors.ToList();

            //Assert
            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void TestCollectionGetter()
        {
            //Act

            Warrior warrior1 = new Warrior("Gosho", 20, 100);
            Warrior warrior2 = new Warrior("Pesho", 30, 200);

            List<Warrior> expectedCollection = new List<Warrior> { warrior1, warrior2 };
            Arena arena = new Arena();

            //Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            //Assert
            Assert.AreEqual(expectedCollection, arena.Warriors);
        }

        [Test]
        public void TestCounterForReturningCorrectCount()
        {
            //Act

            Warrior warrior1 = new Warrior("Gosho", 20, 100);
            Warrior warrior2 = new Warrior("Pesho", 30, 200);

            Arena arena = new Arena();

            //Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            int expectedCount = 2;


            //Assert
            Assert.That(arena.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestCountGetterIfReturnsCountOfCollection()
        {
            Warrior warrior1 = new Warrior("Gosho", 20, 100);
            Warrior warrior2 = new Warrior("Pesho", 30, 200);

            List<Warrior> list = new List<Warrior> { warrior1, warrior2 };
            Arena arena = new Arena();

            //Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            //Assert
            Assert.AreEqual(list.Count, arena.Warriors.Count);
        }

        [Test]
        public void TestEnrollMethodForSuccessfullyAddingWarriorsToCollection()
        {
            Warrior warrior1 = new Warrior("Gosho", 20, 100);
            Warrior warrior2 = new Warrior("Pesho", 30, 200);

            List<Warrior> expectedCollection = new List<Warrior> { warrior1, warrior2 };
            Arena arena = new Arena();

            //Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            //Assert
            Assert.AreEqual(expectedCollection, arena.Warriors);
            Assert.AreEqual(expectedCollection.Count, arena.Warriors.Count);
        }

        [Test]
        public void TestEnrollMethodForThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Warrior warrior1 = new Warrior("Gosho", 20, 100);
                Warrior warrior2 = new Warrior("Gosho", 30, 200);
                Arena arena = new Arena();

                //Act
                arena.Enroll(warrior1);
                arena.Enroll(warrior2);
            },
            //Assert
            "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void TestFightMethodIfWorkingSuccessfully()
        {
            //Arrange
            Warrior warrior1 = new Warrior("Gosho", 60, 100);
            Warrior warrior2 = new Warrior("Pesho", 50, 200);
            Arena arena = new Arena();

            //Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Fight("Gosho", "Pesho");

            //Assert
            Assert.That(warrior2.HP, Is.EqualTo(140));
        }

        [Test]
        public void TestFightMethodWithInvalidAttackerNamer_ThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Warrior warrior1 = new Warrior("Gosho", 20, 100);
                Arena arena = new Arena();

                //Act
                arena.Enroll(warrior1);
                arena.Fight("Peter", "Gosho");
            },
            $"There is no fighter with name Peter enrolled for the fights!");
        }

        [Test]
        public void TestFightMethodWithInvalidDefenderNamer_ThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Warrior warrior1 = new Warrior("Gosho", 20, 100);
                Arena arena = new Arena();

                //Act
                arena.Enroll(warrior1);
                arena.Fight("Gosho", "Spas");
            },
            $"There is no fighter with name Spas enrolled for the fights!");
        }

        [Test]
        public void TestFightMethodWithInvalidNames_ThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Arena arena = new Arena();

                //Act
                arena.Fight("Daniel", "Mihail");
            },
            $"There is no fighter with name Mihail enrolled for the fights!");
        }


    }
}
