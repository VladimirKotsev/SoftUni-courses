namespace SmartphoneShop.Tests
{
    using System;
    using NUnit.Framework;
    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase(-1)]
        [TestCase(-5)]
        public void TestSetterOfCapacity_Excepition(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            },
            "Invalid capacity.");
        }

        [TestCase (0)]
        [TestCase (100)]
        [TestCase (50)]
        public void TestGetterOfCapacity(int capacity)
        {
            Shop shop = new Shop(capacity);

            Assert.AreEqual(capacity, shop.Capacity);
        }

        [Test]
        public void TestCount_ReturningRightValue()
        {
            Shop shop = new Shop(10);
            shop.Add(new Smartphone("G", 100));

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void TestAddMethod_Exception()
        {
            Shop shop = new Shop(10);
            shop.Add(new Smartphone("G", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("G", 100));
            },
            $"The phone model G already exist.");
        }

        [Test]
        public void TestAddMethod_Exception_ExceedingCapacity()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("G", 100));
            shop.Add(new Smartphone("Samsung", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("X", 100));
            },
            "The shop is full.");
        }

        [Test]
        public void TestRemoveMethod_InvalidParameters_Exception()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("G", 100));
            shop.Add(new Smartphone("Samsung", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("X");
            },
            $"The phone model X doesn't exist.");
        }

        [Test]
        public void TestRemoveMethod_RemovingSuccessfully()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("G", 100));
            shop.Add(new Smartphone("Samsung", 100));

            shop.Remove("Samsung");

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void TestTestPhone_Exception_PhoneNotFound()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("G", 100));
            shop.Add(new Smartphone("Samsung", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("X", 20);
            },
            $"The phone model X doesn't exist.");
        }

        [Test]
        public void TestTestPhone_Exception_LessBattery()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("G", 100));
            shop.Add(new Smartphone("Samsung", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("G", 120);
            },
            $"The phone model G is low on batery.");
        }

        [Test]
        public void TestTestMethod_WorkingSuccessfully()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("G", 100);
            shop.Add(phone);
            shop.Add(new Smartphone("Samsung", 100));

            shop.TestPhone("G", 60);

            Assert.AreEqual(phone.CurrentBateryCharge, 40);
        }

        [Test]
        public void TestChargePhone_Exception()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("G", 100);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("X", 20);
            },
            $"The phone model X doesn't exist.");
        }

        [Test]
        public void TestChargePhone_Successfully()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("G", 100);
            shop.Add(phone);
            shop.Add(new Smartphone("Samsung", 100));

            shop.TestPhone("G", 60);

            shop.ChargePhone("G");

            Assert.AreEqual(phone.CurrentBateryCharge, 100);
        }
    }
}