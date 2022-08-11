namespace Gyms.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using System.Reflection;
    using System.Linq;

    public class GymsTests
    {

        [Test]
        public void TestSettersThorughConstructor()
        {
            string name = "Zone";
            int size = 20;
            //List<Athlete> expected = new List<Athlete>();

            Gym newGym = new Gym(name, size);

            Assert.AreEqual(name, newGym.Name);
            Assert.AreEqual(size, newGym.Capacity);
            //CollectionAssert.AreEqual(newGym.)
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestSetterOfName_InvalidParameters_Exception(string parameter)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym newGym = new Gym(parameter, 20);
            });
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void TestSetterOfCapacity_InvalidParameters_Exception(int parameter)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym newGym = new Gym("Zone", parameter);
            },
            "Invalid gym capacity.");
        }

        [Test]
        public void TestGetterCount_ReturnCorrectValue()
        {
            string name = "Zone";
            int size = 20;

            Gym newGym = new Gym(name, size);

            newGym.AddAthlete(new Athlete("Test Test"));
            newGym.AddAthlete(new Athlete("Another Test"));

            Assert.AreEqual(newGym.Count, 2);
        }

        [Test]
        public void TestAddAthleteMethod_ThrowingException_ExceedingCapacity()
        {
            string name = "Zone";
            int size = 2;

            Gym newGym = new Gym(name, size);
            Assert.Throws<InvalidOperationException>(() =>
            {
                newGym.AddAthlete(new Athlete("Test Test"));
                newGym.AddAthlete(new Athlete("Another Test"));
                newGym.AddAthlete(new Athlete("Achki"));
            },
            "The gym is full.");
        }

        [Test]
        public void TestAddAthleteMethod_SuccessfullAdd()
        {
            string name = "Zone";
            int size = 5;

            Gym newGym = new Gym(name, size);
            newGym.AddAthlete(new Athlete("Test Test"));
            newGym.AddAthlete(new Athlete("Another Test"));
            newGym.AddAthlete(new Athlete("Achki"));

            Assert.That(newGym.Count, Is.EqualTo(3));

        }

        [Test]
        public void RemoveAthleteMethod_Exception()
        {
            string name = "Zone";
            int size = 5;

            Gym newGym = new Gym(name, size);
            newGym.AddAthlete(new Athlete("Test Test"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                newGym.RemoveAthlete("Rocky");
            },
            $"The athlete Rocky doesn't exist.");
        }

        [Test]
        public void RemoveAthleteMethod_Success()
        {
            string name = "Zone";
            int size = 5;

            Gym newGym = new Gym(name, size);
            newGym.AddAthlete(new Athlete("Rocky"));
            newGym.AddAthlete(new Athlete("Achki"));

            newGym.RemoveAthlete("Rocky");

            Assert.That(newGym.Count, Is.EqualTo(1));
        }

        [Test]
        public void InjureAthletemethod_Exception()
        {
            string name = "Zone";
            int size = 5;

            Gym newGym = new Gym(name, size);
            newGym.AddAthlete(new Athlete("Rocky"));
            newGym.AddAthlete(new Athlete("Achki"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                newGym.InjureAthlete("Pesho");
            },
            $"The athlete Pesho doesn't exist.");
        }

        [Test]
        public void InjureAthleteMethod_Success()
        {
            string name = "Zone";
            int size = 5;

            Athlete expected = new Athlete("Rocky");
            Gym newGym = new Gym(name, size);
            newGym.AddAthlete(new Athlete("Achki"));
            newGym.AddAthlete(expected);

            Athlete actual = newGym.InjureAthlete("Rocky");
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void TestReportMethod()
        {
            string name = "Zone";
            int size = 5;

            Athlete expected = new Athlete("Rocky");
            Gym newGym = new Gym(name, size);
            newGym.AddAthlete(new Athlete("Achki"));
            newGym.AddAthlete(expected);
            newGym.AddAthlete(new Athlete("Pesho"));

            Athlete actual = newGym.InjureAthlete("Rocky");

            string result = newGym.Report();

            Assert.AreEqual(result, $"Active athletes at {name}: Achki, Pesho");

        }
    }
}