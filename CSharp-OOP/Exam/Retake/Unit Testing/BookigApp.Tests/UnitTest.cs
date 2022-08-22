using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookigApp.Tests
{
    [TestFixture]
    public class Tests
    {
        private const string _FullName = "Hotel";
        private const int _Category = 4;

        [Test]
        public void TestConstructor()
        {
            Hotel hotel = new Hotel("Hotel", 3);

            Assert.IsNotNull(hotel);
        }

        [Test]
        public void TestSettersAndGettersThroughConstructor()
        {
            Hotel hotel = new Hotel(_FullName, _Category);

            Assert.AreEqual(hotel.FullName, _FullName);
            Assert.AreEqual(hotel.Category, _Category);
            Assert.AreEqual(hotel.Turnover, 0);
            CollectionAssert.AreEqual(hotel.Rooms, new List<Room>());
            CollectionAssert.AreEqual(hotel.Bookings, new List<Booking>());

        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("  ")]
        [TestCase("       ")]
        public void TestSetterOfName_InvalidParameter(string parameter)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(parameter, _Category);
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(6)]
        [TestCase(10)]
        public void TestSetterOfCategory_InvalidParameter(int parameter)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel(_FullName, parameter);
            });
        }

        [Test]
        public void TestAddRoom()
        {
            Hotel hotel = new Hotel(_FullName, _Category);
            Room room = new Room(3, 20);

            hotel.AddRoom(room);

            CollectionAssert.AreEqual(new List<Room>() { room }, hotel.Rooms);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        public void TestBookRoom_FirstException(int parameter)
        {
            Hotel hotel = new Hotel(_FullName, _Category);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(parameter, 5, 5, 100);
            });
        }

        [TestCase (-1)]
        [TestCase (-5)]
        public void TestBookRoom_SecondException(int parameter)
        {
            Hotel hotel = new Hotel(_FullName, _Category);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(5, parameter, 5, 100);
            });
        }

        [TestCase (0)]
        [TestCase (-1)]
        [TestCase (-5)]
        public void TestBookRoom_ThirdException(int parameter)
        {
            Hotel hotel = new Hotel(_FullName, _Category);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(5, 5, parameter, 100);
            });
        }

        [Test]
        public void TestBookRoomMethod_LowBudget()
        {
            Hotel hotel = new Hotel(_FullName, _Category);

            Room room = new Room(5, 50);
            hotel.AddRoom(room);

            hotel.BookRoom(2, 3, 5, 100);

            CollectionAssert.AreEqual(new List<Booking>(), hotel.Bookings);
        }

        [Test]
        public void TestBookRoomMethod_NoRoomWithThatCapacity()
        {
            Hotel hotel = new Hotel(_FullName, _Category);

            Room room = new Room(5, 20);
            hotel.AddRoom(room);

            hotel.BookRoom(2, 5, 5, 400);

            CollectionAssert.AreEqual(new List<Booking>(), hotel.Bookings);
        }

        [Test]
        public void TestBookRoomMethod_Successfull()
        {
            Hotel hotel = new Hotel(_FullName, _Category);

            Room room = new Room(5, 20);
            hotel.AddRoom(room);

            Booking expectedBooking = new Booking(1, room, 5);

            hotel.BookRoom(2, 3, 5, 200);
            List<Booking> expected = new List<Booking>() { expectedBooking };

            Assert.AreEqual(1, hotel.Bookings.Count);

            Assert.AreEqual(hotel.Bookings.First().Room, room);
            Assert.AreEqual(hotel.Bookings.First().BookingNumber, 1);
            Assert.AreEqual(hotel.Bookings.First().ResidenceDuration, 5);
            Assert.AreEqual(hotel.Turnover, 5 * 20);
        }
    }
}