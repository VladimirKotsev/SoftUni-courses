namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        [Test]
        public void TestConstructor()
        {
            string username = "Arto";
            int maxBatteryLife = 100;
            Robot robot = new Robot(username, maxBatteryLife);

            Assert.IsNotNull(robot);
        }

        [Test]
        public void TestGetterOfPropertyName()
        {
            string username = "Arto";
            int maxBatteryLife = 100;
            Robot robot = new Robot(username, maxBatteryLife);

            Assert.That(robot.Name, Is.EqualTo(username));
        }

        [Test]
        public void TestGetterOfPropertyMaxBattery()
        {
            string username = "Arto";
            int maxBatteryLife = 100;
            Robot robot = new Robot(username, maxBatteryLife);

            Assert.That(robot.MaximumBattery, Is.EqualTo(maxBatteryLife));
        }

        [Test]
        public void TestGetterOfPropertyBattery()
        {
            string username = "Arto";
            int maxBatteryLife = 100;
            Robot robot = new Robot(username, maxBatteryLife);

            Assert.That(robot.Battery, Is.EqualTo(maxBatteryLife));
        }
    }
}