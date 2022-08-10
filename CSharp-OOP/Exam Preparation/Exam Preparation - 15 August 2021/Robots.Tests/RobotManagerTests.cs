namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    public class RobotManagerTests
    {
        [Test]
        public void TestConstructor()
        {
            RobotManager robotManager = new RobotManager(10);
            Assert.IsNotNull(robotManager);
        }

        [Test]
        public void TestSetterOfCollection()
        {
            RobotManager robotManager = new RobotManager(10);
            Type type = typeof(RobotManager);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(x => x.Name == "robots");

            Assert.IsNotNull(field);
        }

        [Test]
        public void TestSetterOfCapacity()
        {
            RobotManager robotManager = new RobotManager(10);
            Assert.That(robotManager.Capacity, Is.EqualTo(10));
        }

        [TestCase (-1)]
        [TestCase (-5)]
        public void TestCapacityWithInvalidParameter_Exception(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(capacity);
            },
            "Invalid capacity!");
        }

        [Test]
        public void TestGetterCount()
        {
            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Arto", 100));
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestAddMethodWithAlreadyExistingRobot()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("Arto", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot2);

            },
            $"There is already a robot with name {robot1.Name}!");
        }

        [Test]
        public void TestAddMethodForExcessingCapacity()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(1);

            robotManager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot2);
            },
            "Not enough capacity!");
        }

        [Test]
        public void TestAddMethodForAddingSuccessfully()
        {

            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.That(robotManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestRemoveMethod_ThrowingException()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Him");
            },
            $"Robot with the name Him doesn't exist!");
        }

        [Test]
        public void TestRemoveMethodForWorkingSuccessfully()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            robotManager.Remove("Arto");

            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestWorkMethod_ThrowingException_RobotNotFound()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Pesho", "Coding", 20);
            },
            $"Robot with the name Pesho doesn't exist!");
        }

        [Test]
        public void TestWorkMethod_ThrowingException_LowerBattery()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Arto", "Coding", 300);
            },
            $"Arto doesn't have enough battery!");
        }

        [Test]
        public void TestWorkMethod_Working()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            robotManager.Work("Arto", "Coding", 45);

            Assert.That(robot1.Battery, Is.EqualTo(55));
        }

        [Test]
        public void TestChargeMethod_ThrowingException_RobotNotFound()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Pesho");
            },
            $"Robot with the name Pesho doesn't exist!");
        }

        [Test]
        public void TestChargeMethod_Working()
        {
            Robot robot1 = new Robot("Arto", 100);
            Robot robot2 = new Robot("George", 100);

            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            robotManager.Work("Arto", "Coding", 45);
            robotManager.Charge("Arto");

            Assert.That(robot1.Battery, Is.EqualTo(100));
        }

    }
}
