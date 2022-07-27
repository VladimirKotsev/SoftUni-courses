using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            //Arrange
            var axe = new Axe(10, 10);
            var dummy = new Dummy(30, 20);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(20), "Dummmy doesn't lose health");

        }

        [Test]
        public void DeadDummyThrowsExceptionWhenAttacked()
        {
            Assert.That(() =>
            {
                //Arrange
                var axe = new Axe(10, 10);
                var dummy = new Dummy(10, 20);

                //Act
                axe.Attack(dummy);
                axe.Attack(dummy);

            },
            //Assert
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Dummy is dead.");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            //Arrange
            var axe = new Axe(10, 10);
            var dummy = new Dummy(10, 20);

            //Act
            axe.Attack(dummy);
            int xp = dummy.GiveExperience();

            //Assert
            Assert.That(xp, Is.EqualTo(20), "Dummy doesn't give xp when dead!");

        }

        [Test]
        public void AliveDummyCantGiveXp()
        {
            Assert.That(() =>
            {
                //Arrange
                var dummy = new Dummy(20, 20);

                //Act
                int xp = dummy.GiveExperience();
            },
            //Assert
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Target is not dead.");
        }
    }
}
