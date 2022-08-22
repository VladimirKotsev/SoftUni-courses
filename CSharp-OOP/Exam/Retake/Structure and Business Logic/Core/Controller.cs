namespace BookingApp.Core
{
    using System;

    using Contracts;
    using Repositories;
    using Models.Hotels.Contacts;
    using Models.Hotels;
    using Utilities.Messages;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Models.Rooms;
    using System.Collections.Generic;
    using System.Linq;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Models.Bookings.Contracts;
    using System.Text;
    using BookingApp.Models.Bookings;

    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel != null)
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotel = new Hotel(hotelName, category);
            this.hotels.AddNew(hotel);

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel is null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IRoom room = this.hotels.Select(hotelName).Rooms.Select(roomTypeName);
            if (room != null)
            {
                return String.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            if (roomTypeName == "Apartment")
            {
                room = new Apartment();
                this.hotels.Select(hotelName).Rooms.AddNew(room);
            }
            else if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
                this.hotels.Select(hotelName).Rooms.AddNew(room);
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
                this.hotels.Select(hotelName).Rooms.AddNew(room);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel is null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != "Studio" && roomTypeName != "DoubleBed" && roomTypeName != "Apartment")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = this.hotels.Select(hotelName).Rooms.Select(roomTypeName);
            if (room is null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);

        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            IReadOnlyCollection<IHotel> hotelsAvailble = this.hotels.All()
                .Where(x => x.Category == category)
                .OrderBy(x => x.FullName)
                .ToList();

            if (hotelsAvailble.Count == 0)
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            int count = adults + children;

            IRoom actualRoom = hotelsAvailble
                .SelectMany(x => x.Rooms.All()
                .Where(x => x.PricePerNight > 0)
                .OrderBy(t => t.BedCapacity))
                .FirstOrDefault(z => z.BedCapacity >= count);

            if (actualRoom is null)
            {
                return OutputMessages.RoomNotAppropriate;
            }

            IHotel hotel = null;

            foreach (var h in hotelsAvailble)
            {
                foreach (var room in h.Rooms.All())
                {
                    if (room.GetType().Name == actualRoom.GetType().Name &&
                        room.BedCapacity == actualRoom.BedCapacity &&
                        room.PricePerNight == actualRoom.PricePerNight)
                    {
                        hotel = h;
                        break;
                    }
                }
            }

            hotel.Bookings.AddNew(new Booking(actualRoom, duration, adults, children, hotel.Bookings.All().Count + 1));

            return String.Format(OutputMessages.BookingSuccessful, hotel.Bookings.All().Last().BookingNumber, hotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            StringBuilder sb = new StringBuilder();

            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel is null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();

        }


    }
}
