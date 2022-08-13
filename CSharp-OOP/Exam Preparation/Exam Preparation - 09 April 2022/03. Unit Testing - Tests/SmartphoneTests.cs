namespace SmartphoneShop
{
    using System;
    using NUnit.Framework;
    public class SmartphoneTests
    {
        [TestCase ("Samsung")]
        [TestCase ("Apple")]
        public void TestModelNameSetter(string model)
        {
            Smartphone smartphone = new Smartphone(model, 100);

            Assert.AreEqual(model, smartphone.ModelName);
        }

        [TestCase (10)]
        [TestCase (100)]
        public void TestBatterySetterAndGetter(int batteryLife)
        {
            Smartphone smartphone = new Smartphone("Samsung", batteryLife);

            Assert.AreEqual(smartphone.MaximumBatteryCharge, batteryLife);
        }

        [TestCase(10)]
        [TestCase(100)]
        public void TestCurrentBatterySetterAndGetter(int batteryLife)
        {
            Smartphone smartphone = new Smartphone("Samsung", batteryLife);

            Assert.AreEqual(smartphone.CurrentBateryCharge, batteryLife);
        }



    }
}
