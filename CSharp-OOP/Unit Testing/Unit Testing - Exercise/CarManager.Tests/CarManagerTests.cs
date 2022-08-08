namespace CarManager.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void TestConstructorsWithValidParameters()
        {
            //Arrange & Act
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.00;
            double fuelCapacity = 40.5;

            var myCar = new Car(make, model, fuelConsumption, fuelCapacity);

            //Assert
            Assert.IsNotNull(myCar);
            Assert.That(myCar.FuelAmount, Is.EqualTo(0));
            Assert.That(myCar.FuelCapacity, Is.EqualTo(fuelCapacity));
            Assert.That(myCar.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(myCar.Model, Is.EqualTo(model));
            Assert.That(myCar.Make, Is.EqualTo(make));
        }

        [TestCase (null)]
        [TestCase ("")]
        public void TestClassWithInvalidMake(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Аrrange & Act
                var myCar = new Car(make, "civic", 6.00, 40.5);
            },
            //Assert
            "Make cannot be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestClassWithInvalidModel(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Аrrange & Act
                var myCar = new Car("Honda", model, 6.00, 40.5);
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
                ("Honda", "civic", 6.00, fuelCapacity);
            },
            //Assert
            "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void TestGetterOfMake()
        {
            //Arrange & Act
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.00;
            double fuelCapacity = 40.5;

            var myCar = new Car(make, model, fuelConsumption, fuelCapacity);

            //Assert
            Assert.That(myCar.Make, Is.EqualTo(make));
        }


        [Test]
        public void TestGetterOfModel()
        {
            //Arrange & Act
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.00;
            double fuelCapacity = 40.5;

            var myCar = new Car(make, model, fuelConsumption, fuelCapacity);

            //Assert
            Assert.That(myCar.Model, Is.EqualTo(model));
        }

        [Test]
        public void TestGetterOfFuelConsumption()
        {
            //Arrange & Act
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.00;
            double fuelCapacity = 40.5;

            var myCar = new Car(make, model, fuelConsumption, fuelCapacity);

            //Assert
            Assert.That(myCar.FuelConsumption, Is.EqualTo(fuelConsumption));
        }

        [Test]
        public void TestGetterOfFuelCapacity()
        {
            //Arrange & Act
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.00;
            double fuelCapacity = 40.5;

            var myCar = new Car(make, model, fuelConsumption, fuelCapacity);

            //Assert
            Assert.That(myCar.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        public void TestGetterOfFuelAmount()
        {
            //Arrange & Act
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.00;
            double fuelCapacity = 40.5;

            var myCar = new Car(make, model, fuelConsumption, fuelCapacity);

            //Assert
            Assert.That(myCar.FuelAmount, Is.EqualTo(0));
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

        [TestCase (50)]
        [TestCase (20)]
        [TestCase (16)]
        public void TestRefuelMethodForExcessingFuelCapacity_Successfully(double litters)
        {
            //Аrrange
            var myCar = new Car
            ("Honda", "civic", 6.00, 15);
            double expectedLitters = 15;

            //Act
            myCar.Refuel(litters);

            //Assert
            Assert.That(myCar.FuelAmount, Is.EqualTo(expectedLitters));

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
            double expectedLitters = litters;

            //Act
            myCar.Refuel(litters);

            //Assert
            Assert.That(myCar.FuelAmount, Is.EqualTo(expectedLitters));
        }

        [TestCase (10)]
        [TestCase (5)]
        [TestCase (2)]
        public void TestDriveMethodNoFuel_ThrowingException(double kilometers)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Аrrange
                var myCar = new Car
                ("Honda", "civic", 6.00, 40.5);

                //Act
                myCar.Drive(kilometers);

            },
            //Assert
            "You don't have enough fuel to drive!");
        }
        [TestCase (100, 2)]
        [TestCase (500, 5)]
        [TestCase (10, 0.5)]
        [TestCase (1000, 50)]
        public void TestDriveMethodWithFuel_ThrowingException(double kilometers, double litters)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                string make = "Honda";
                string model = "Civic";
                double fuelConsumption = 10.00;
                double fuelCapacity = 40.5;

                var myCar = new Car(make, model, fuelConsumption, fuelCapacity);

                //Act
                myCar.Refuel(litters);

                myCar.Drive(kilometers);
            },
            //Assert
            "You don't have enough fuel to drive!");
        }

        [TestCase (800, 40)]
        [TestCase(799, 40)]
        [TestCase(240, 40)]
        [TestCase(119, 40)]
        [TestCase(0, 10)]
        public void TestDriveMethodForSuccessfullyDriving(double kilometers, double litters)
        {
            //Arrange
            var myCar = new Car ("Honda", "Civic", 5.00, litters);
            myCar.Refuel(litters);
            double expectedAmount = litters - (kilometers / 100) * 5.00;

            //Act
            myCar.Drive(kilometers);

            //Assert
            Assert.That(myCar.FuelAmount, Is.EqualTo(expectedAmount));
        }
    }
}