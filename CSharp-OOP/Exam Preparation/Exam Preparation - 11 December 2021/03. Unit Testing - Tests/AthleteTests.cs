namespace Gyms.Tests
{
    using NUnit.Framework;
    public class AthleteTests
    {
        [Test]
        public void TestGettersThroughConstructor()
        {
            Athlete athlete = new Athlete("Pesho");

            Assert.That(athlete.FullName, Is.EqualTo("Pesho"));
            Assert.That(athlete.IsInjured, Is.EqualTo(false));
        }
    }
}
