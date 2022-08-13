using NUnit.Framework;

namespace RepairShop.Tests
{
    using System;

    public class RepairsShopTests
    {
        private Garage _garage;
        private string _name = "JivkoRepairs";
        private int _mechanics = 3;

        [SetUp]
        public void SetUp()
        {
            string name = "JivkoRepairs";
            int mechanics = 3;
            Garage garage = new Garage(name, mechanics);
            this._garage = garage;
        }


        [TestCase(null)]
        [TestCase("")]
        public void TestSetterOfName_Exception(string parameter)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Garage garage = new Garage(parameter, _mechanics);
            }
            );
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void TestSetterOfMechanicsAvailable(int parameter)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Garage garage = new Garage(_name, parameter);
            },
            "At least one mechanic must work in the garage.");
        }

        [Test]
        public void TestGettersOfProperties()
        {
            Assert.That(this._garage.Name, Is.EqualTo("JivkoRepairs"));
            Assert.AreEqual(this._garage.MechanicsAvailable, 3);
        }

        [Test]
        public void TestGetterOfCount()
        {
            _garage.AddCar(new Car("Honda", 3));
            _garage.AddCar(new Car("Toyota", 2));

            Assert.AreEqual(_garage.CarsInGarage, 2);
        }

        [Test]
        public void TestAddMethod_Exception_NoMechanicsAvalible()
        {
            _garage.AddCar(new Car("Honda", 3));
            _garage.AddCar(new Car("Toyota", 2));
            _garage.AddCar(new Car("Another Car", 5));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _garage.AddCar(new Car("Honda", 5));
            },
            "No mechanic available.");
        }

        [Test]
        public void AddCarSuccessfully()
        {
            _garage.AddCar(new Car("Honda", 3));
            _garage.AddCar(new Car("Toyota", 2));
            _garage.AddCar(new Car("Another Car", 5));

            Assert.AreEqual(_garage.CarsInGarage, 3);
        }

        [Test]
        public void FixCar_Exception_CarNotFound()
        {
            _garage.AddCar(new Car("Honda", 3));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _garage.FixCar("Toyota");
            },
            $"The car Toyota doesn't exist.");
        }

        [Test]
        public void FixCar_Successfull()
        {
            Car honda = new Car("Honda", 3);
            _garage.AddCar(honda);

            Car actualCar = _garage.FixCar("Honda");

            Assert.AreEqual(honda.NumberOfIssues, 0);
            Assert.AreEqual(honda.IsFixed, true);
            Assert.AreEqual(actualCar, honda);
        }

        [Test]
        public void RemoveFixedCars_Exception_NoFixedCars()
        {
            _garage.AddCar(new Car("Honda", 3));
            _garage.AddCar(new Car("Toyota", 2));
            _garage.AddCar(new Car("Another Car", 5));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _garage.RemoveFixedCar();
            },
            $"No fixed cars available.");
        }

        [Test]
        public void RemoveFixedCars_Successfull()
        {
            _garage.AddCar(new Car("Honda", 3));
            _garage.AddCar(new Car("Toyota", 2));
            _garage.AddCar(new Car("Another Car", 5));

            _garage.FixCar("Honda");
            _garage.FixCar("Toyota");

            _garage.RemoveFixedCar();

            Assert.AreEqual(_garage.CarsInGarage, 1);
        }

        [Test]
        public void TestReportMethod()
        {
            _garage.AddCar(new Car("Honda", 3));
            _garage.AddCar(new Car("Toyota", 2));
            _garage.AddCar(new Car("Another Car", 5));

            string result = _garage.Report();

            Assert.AreEqual(result, $"There are 3 which are not fixed: Honda, Toyota, Another Car.");
        }
    }
}