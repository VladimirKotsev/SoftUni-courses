namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void TestConstructorsWithValidParameters()
        {
            //Arrange & Act
            var myCar = new Car("Honda", "civic", 6.00, 40.5);

            //Assert
            Assert.IsNotNull(myCar);
            Assert.That(myCar.FuelAmount, Is.EqualTo(0));
            Assert.That(myCar.FuelCapacity, Is.EqualTo(40.5));
            Assert.That(myCar.FuelConsumption, Is.EqualTo(6.00));
            Assert.That(myCar.Model, Is.EqualTo("civic"));
            Assert.That(myCar.Make, Is.EqualTo("Honda"));
        }

        [Test]
        public void TestClassWithInvalidMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Аrrange & Act
                var myCar = new Car("", "civic", 6.00, 40.5);
            },
            //Assert
            "Make cannot be null or empty!");
        }

        [Test]
        public void TestClassWithInvalidModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Аrrange & Act
                var myCar = new Car("Honda", "", 6.00, 40.5);
            },
            //Assert
            "Model cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void TestClassWithInvalidFuelConsumption(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Аrrange & Act
                var myCar = new Car
                ("Honda", "civic", fuelConsumption, 40.5);
            },
            //Assert
            "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]

        public void TestClassWithInvalidFuelCapacity(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Аrrange & Act
                var myCar = new Car
                ("Honda", "civic", fuelCapacity, 40.5);
            },
            //Assert
            "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void TestRefuelMethodForThrowingException(double litters)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Аrrange
                var myCar = new Car
                ("Honda", "civic", 6.00, 40.5);

                //Act
                myCar.Refuel(litters);

            },
            //Assert
            "Fuel amount cannot be zero or negative!");
        }

        [TestCase(50)]
        [TestCase(20)]
        public void TestRefuelMethodForExceedingFuelCapacity_Successfully(double litters)
        {
            //Аrrange
            var myCar = new Car
            ("Honda", "civic", 6.00, 15);

            //Act
            myCar.Refuel(litters);

            //Assert
            Assert.That(myCar.FuelAmount, Is.EqualTo(15));

        }

        [TestCase (20)]
        [TestCase (40.5)]
        [TestCase (30)]
        [TestCase (1)]
        public void TestRefuelMethod_Successfully(double litters)
        {
            //Аrrange
            var myCar = new Car
            ("Honda", "civic", 6.00, 40.5);

            //Act
            myCar.Refuel(litters);

            //Assert
            Assert.That(myCar.FuelAmount, Is.GreaterThan(0));
            Assert.That(myCar.FuelAmount, Is.LessThanOrEqualTo(40.5));
        }

        [Test]
        public void TestDriveMethodForThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Аrrange
                var myCar = new Car
                ("Honda", "civic", 6.00, 40.5);

                //Act
                myCar.Drive(2);

            },
            //Assert
            "You don't have enough fuel to drive!");
        }

        [Test]
        public void TestDriveMethodForSuccessfullyDriving()
        {
            //Arrange
            var myCar = new Car ("Honda", "civic", 6.00, 40.5);
            myCar.Refuel(40.5);

            //Act
            myCar.Drive(240);

            //Assert
            Assert.That(myCar.FuelAmount, Is.EqualTo(26.1));
        }
    }
}