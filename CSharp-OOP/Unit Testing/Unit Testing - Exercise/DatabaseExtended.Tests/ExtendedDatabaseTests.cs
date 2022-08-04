namespace DatabaseExtended.Tests
{
    using System;
    using NUnit.Framework;

    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void TestConstructorForInvalidParameters()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                Person[] persons = new Person[]
                {
                    new Person(1, "Pesho"), new Person(2, "Teodor"), new Person(3, "Someone"),
                    new Person(4, "Penka"), new Person(5, "Someone else"), new Person(6, "Me"),
                    new Person(7, "Him"), new Person(8, "Her"), new Person(9, "His"),
                    new Person(10, "Hers"), new Person(11, " "),
                    new Person(12, "  else"), new Person(13, "   "), new Person(14, "Nobody"),
                    new Person(15, "There"),  new Person(16, "Here"), new Person(17, "I'm here"),
                    new Person(18, "It's annoying")
                };

                var database = new Database(persons);


            },
            //Assert
            "Provided data length should be in range [0..16]!");
        }


        [Test]
        public void TestAddMethodForDublicativeUsername_ThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Person[] persons = new Person[]
                {
                    new Person(1, "Peesho"),
                    new Person(2, "Peesho")
                };

                var database = new Database(persons);
            },
            "There is already user with this username!");

        }

        [Test]
        public void TestAddMethodForDuplicativeIds()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Person[] persons = new Person[]
                {
                    new Person(1, "Gosho"),
                    new Person(1, "Peesho")
                };

                //Act
                var database = new Database(persons);
            },
            //Assert
            "There is already user with this Id!");
        }

        [Test]
        public void TestAddMethodForExcessingCapacity()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Person[] persons = new Person[]
                {
                    new Person(1, "Pesho"), new Person(2, "Teodor"), new Person(3, "Someone"),
                    new Person(4, "Penka"), new Person(5, "Someone else"), new Person(6, "Me"),
                    new Person(7, "Him"), new Person(8, "Her"), new Person(9, "His"),
                    new Person(10, "Hers"), new Person(11, " "),
                    new Person(12, "  else"), new Person(13, "   "), new Person(14, "Nobody"),
                    new Person(15, "There"),  new Person(16, "Here")
                };

                var database = new Database(persons);

                //Act
                database.Add(new Person(17, "ShouldThrowException"));

            },
            //Assert
            "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodWorks()
        {
            //Arrange
            Person[] persons = new Person[]
            {
                    new Person(1, "Pesho")
            };

            var database = new Database(persons);

            //Act
            database.Add(new Person(2, "Gosho"));

            //Assert
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestRemoveMethodForThrowingExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Person[] persons = new Person[]
                {
                    new Person(1, "Pesho")
                };

                var database = new Database(persons);

                //Act
                database.Remove();
                database.Remove();

            },
            //Assert
            "");
        }

        [Test]
        public void RemoveMethodShouldWork()
        {
            //Arrange
            Person[] persons = new Person[]
            {
                    new Person(1, "Pesho"),
                    new Person(2, "Gosho")
            };

            var database = new Database(persons);

            //Act
            database.Remove();

            int count = database.Count;

            //Assert
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void FindByNullOrEmptyUsername()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Arrange
                Person[] persons = new Person[]
                {
                    new Person(1, "Pesho")
                };

                var database = new Database(persons);

                //Act
                database.FindByUsername("");

            },
            "Username parameter is null!");
        }

        [Test]
        public void FindByNonExistingUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Person[] persons = new Person[]
                {
                    new Person(1, "Pesho")
                };

                var database = new Database(persons);

                //Act
                database.FindByUsername("Gosho");

            },
            "No user is present by this username!");
        }

        [Test]
        public void FindByUsernameSuccesfully()
        {
            //Arrange
            Person[] persons = new Person[]
            {
                    new Person(1, "Pesho")
            };

            var database = new Database(persons);

            //Act
            Person person = database.FindByUsername("Pesho");

            //Assert
            Assert.That(person, Is.EqualTo(persons[0]));
        }

        [Test]
        public void FindByNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                //Arrange
                Person[] persons = new Person[]
                {
                    new Person(1, "Pesho")
                };

                var database = new Database(persons);

                //Act
                database.FindById(-2);

            },
            "Id should be a positive number!");
        }

        [Test]
        public void FindByInvalidId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Person[] persons = new Person[]
                {
                    new Person(1, "Pesho")
                };

                var database = new Database(persons);

                //Act
                database.FindById(5);

            },
            "No user is present by this ID!");
        }

        [Test]
        public void FindByIdSuccesfully()
        {
            //Arrange
            Person[] persons = new Person[]
            {
                new Person(5, "Pesho")
            };

            var database = new Database(persons);

            //Act
            Person person = database.FindById(5);

            //Assert
            Assert.That(person, Is.EqualTo(persons[0]));
        }

    }
}