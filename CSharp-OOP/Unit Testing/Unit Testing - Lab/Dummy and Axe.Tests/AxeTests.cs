using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeWeaponDurabilityReduction()
        {
            //Arrange
            var axe = new Axe(10, 10);
            var dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doens't change after attack.");
        }

        [Test]
        public void BrokenAxeAttacking()
        {
            Assert.That(() =>
            {
                //Arrange
                var axe = new Axe(10, 0);
                var dummy = new Dummy(10, 10);

                //Act
                axe.Attack(dummy);
            },
            //Assert
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Axe is broken.");

        }
    }
}