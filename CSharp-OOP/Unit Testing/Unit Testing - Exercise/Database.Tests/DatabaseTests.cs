namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };


        [Test]
        public void TestAddMethod_ThrowingException()
        {
            Assert.That(() =>
            {
                //Arrange
                var database = new Database(array);

                //Act
                database.Add(17);
            },
            //Assert
            Throws.Exception.TypeOf<InvalidOperationException>(),
                "Database class doesn't throw exception when adding over it's capacity");

        }

        [Test]
        public void TestRemoveMethod_ThrowingException()
        {
            Assert.That(() =>
            {
                //Arrange
                var database = new Database(new int[] { 1, });

                //Act
                database.Remove();
                database.Remove();
            },
            //Assert
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Database doesn't throw exception when removing from an empty database");
        }

        [Test]
        public void TestContructorWith0Parameters()
        {
            //Arrange & Act
            var database = new Database(new int[] { });

            //Assert
            Assert.That(database.Fetch().Length, Is.EqualTo(0));
            Assert.That(database.Count, Is.EqualTo(0));
        }


        [Test]
        public void TestFetchMethod()
        {
            //Arrange
            var database = new Database(new int[] { 1, 2, 3, 4, 5 });

            //Act
            var check = database.Fetch();

            //Assert
            Assert.That(check, Is.EqualTo(new int[] {1, 2, 3, 4, 5}));
        }

        [Test]
        public void CountShouldReturnCount()
        {
            //Arrange
            var database = new Database(new int[] { 1, 2, 3 });

            //Act
            int count = database.Count;

            //Assert
            Assert.That(database.Fetch().Length, Is.EqualTo(count));

        }
    }
}