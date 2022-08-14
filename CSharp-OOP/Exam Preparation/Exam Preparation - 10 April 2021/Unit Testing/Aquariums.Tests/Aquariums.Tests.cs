namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;


    public class AquariumsTests
    {
        private string _name = "Varna";
        private int _capacity = 10;

        [Test]
        public void TestConstructor()
        {
            Aquarium aquarium = new Aquarium(this._name, this._capacity);

            Type classType = aquarium.GetType();
            //FieldInfo nameInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(x => x.Name == "name");
            //string name = nameInfo.GetValue(object? obj) as string;

            Assert.That(aquarium, Is.Not.Null);      
        }

        [Test]
        public void TestGettersThorughtConstructor()
        {
            Aquarium aquarium = new Aquarium(this._name, this._capacity);

            Assert.AreEqual(this._name, aquarium.Name);
            Assert.AreEqual(this._capacity, aquarium.Capacity);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestNameSetter_Exception(string parameter)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(parameter, this._capacity);
            },
            "Name Invalid aquarium name!");

        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void TestCapacitySetter_Exception(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium(this._name, capacity);
            },
            "Invalid aquarium capacity!");
        }

        [Test]
        public void TestCountGetter_Successfull()
        {
            Aquarium aquarium = new Aquarium(this._name, this._capacity);

            aquarium.Add(new Fish("Gold"));

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void TestAddMethod_ExceedingCapacity()
        {
            Aquarium aquarium = new Aquarium(this._name, 1);

            Fish fish1 = new Fish("Gold");
            Fish fish2 = new Fish("Silver");

            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish2);
            },
            "Aquarium is full!");
        }

        [Test]
        public void TestAddMethod_SuccessfullAdd()
        {
            Aquarium aquarium = new Aquarium(this._name, this._capacity);

            Fish fish1 = new Fish("Gold");
            Fish fish2 = new Fish("Silver");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void TestRemoveMethod_Exception_FishNotFound()
        {
            Aquarium aquarium = new Aquarium(this._name, _capacity);

            Fish fish1 = new Fish("Gold");
            Fish fish2 = new Fish("Silver");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Bronze");
            },
            $"Fish with the name Bronze doesn't exist!");
        }

        [Test]
        public void TestRemoveMethod_SuccessfullRemove()
        {
            Aquarium aquarium = new Aquarium(this._name, this._capacity);

            Fish fish1 = new Fish("Gold");
            Fish fish2 = new Fish("Silver");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            aquarium.RemoveFish("Gold");

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void TestSellFishMethod_Exception_FishNotFound()
        {
            Aquarium aquarium = new Aquarium(this._name, _capacity);

            Fish fish1 = new Fish("Gold");
            Fish fish2 = new Fish("Silver");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Bronze");
            },
            $"Fish with the name Bronze doesn't exist!");
        }

        [Test]
        public void TestSellFishMethod_Successfull()
        {
            Aquarium aquarium = new Aquarium(this._name, _capacity);

            Fish fish1 = new Fish("Gold");
            Fish fish2 = new Fish("Silver");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Fish actual = aquarium.SellFish("Gold");

            Assert.AreEqual(fish1, actual);
            Assert.AreEqual(fish1.Available, false);
        }

        [Test]
        public void TestReportMethod()
        {
            Aquarium aquarium = new Aquarium(this._name, _capacity);

            Fish fish1 = new Fish("Gold");
            Fish fish2 = new Fish("Silver");

            aquarium.Add(fish1);
            aquarium.Add(fish2);


            string result = aquarium.Report();

            Assert.AreEqual($"Fish available at {this._name}: Gold, Silver", result);
        }
    }
}