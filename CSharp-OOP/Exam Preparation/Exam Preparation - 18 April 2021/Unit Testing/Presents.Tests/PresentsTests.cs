namespace Presents.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void TestConstructor()
        {
            Bag bag = new Bag();

            Assert.IsNotNull(bag);
        }

        [Test]
        public void TestSetterOfCollection()
        {
            Bag bag = new Bag();

            CollectionAssert.AreEqual(new List<Present>(), bag.GetPresents());
            Assert.AreEqual(0, bag.GetPresents().Count);
        }
        
        [Test]
        public void CreateMethod_Exception_PresentIsNull()
        {
            Present present = null;
            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            },
            "Present is null");
        }

        [Test]
        public void CreateMethod_Exception_PresentExists()
        {
            Present present = new Present("Cars", 10.5);
            Bag bag = new Bag();
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            },
            "This present already exists!");
        }

        [Test]
        public void CreateMethod_Successfull()
        {
            Present present = new Present("Cars", 10.5);
            Bag bag = new Bag();
            string result = bag.Create(present);

            Assert.AreEqual(result, $"Successfully added present Cars.");
            Assert.AreEqual(bag.GetPresents().Count, 1);

            CollectionAssert.AreEqual(new List<Present>() { present }, bag.GetPresents());
        }

        [Test]
        public void RemoveMethod_RetursSuccessfull()
        {
            Present present = new Present("Cars", 10.5);
            Bag bag = new Bag();
            bag.Create(present);

            Assert.AreEqual(bag.Remove(present), true);
        }

        [Test]
        public void RemoveMethod_ReturnsNotSuccessfull()
        {
            Present present = new Present("Cars", 10.5);
            Bag bag = new Bag();

            Assert.AreEqual(bag.Remove(present), false);
        }

        [Test]
        public void TestGetPresentWithLeastMagic()
        {
            Present present = new Present("Cars", 10.5);
            Present present2 = new Present("Dolls", 20);
            Present present3 = new Present("RC car", 5);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            Present resultPresent = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(resultPresent, present3);
        }

        [Test]
        public void TestGetPresent()
        {
            Present present = new Present("Cars", 10.5);
            Present present2 = new Present("Dolls", 20);
            Present present3 = new Present("RC car", 5);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            Assert.AreEqual(bag.GetPresent("Cars"), present);
            Assert.AreEqual(bag.GetPresent("Dolls"), present2);
            Assert.AreEqual(bag.GetPresent("RC car"), present3);
        }

        [Test]
        public void TestGetPresent_NonExistingPresent()
        {
            Present present = new Present("Cars", 10.5);
            Present present2 = new Present("Dolls", 20);
            Present present3 = new Present("RC car", 5);

            Bag bag = new Bag();
            bag.Create(present);

            Assert.AreEqual(null, bag.GetPresent("Cubes"));
        }
    }
}