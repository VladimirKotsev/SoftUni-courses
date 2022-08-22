namespace BookingApp.Models.Hotels
{
    using System;
    using System.Linq;

    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using BookingApp.Repositories.Contracts;
    using Contacts;
    using Utilities.Messages;
    public class Hotel : IHotel
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                fullName = value;
            }
        }

        private int category;
        public int Category
        {
            get { return category; }
            private set
            {
                if (value < 1 && value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double sum = 0;
                foreach (var booking in this.Bookings.All())
                {
                    sum += Math.Round(booking.ResidenceDuration * booking.Room.PricePerNight, 2);
                }
                
                return sum;
            }
        }


        private IRepository<IRoom> rooms;
        public IRepository<IRoom> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        private IRepository<IBooking> bookings;
        public IRepository<IBooking> Bookings
        {
            get { return bookings; }
            set { bookings = value; }
        }

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }
    }
}
