namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;

    using Models.Rooms.Contracts;
    using Contracts;
    using Utilities.Messages;
    public class Booking : IBooking
    {
        private IRoom room;
        public IRoom Room
        {
            get { return room; }
            private set { room = value; }
        }

        private int residenceDuration;
        public int ResidenceDuration
        {
            get { return residenceDuration; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                residenceDuration = value;
            }
        }

        private int adultsCount;
        public int AdultsCount
        {
            get { return adultsCount; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                adultsCount = value;
            }
        }

        private int childrenCount;
        public int ChildrenCount
        {
            get { return childrenCount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                childrenCount = value;
            }
        }

        private int bookingNumber;
        public int BookingNumber
        {
            get { return bookingNumber; }
            private set { bookingNumber = value; }
        }

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public double TotalPaid()
        {
            return Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
        }

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Total amount paid: {this.TotalPaid():F2} $");

            return sb.ToString().TrimEnd();
        }
    }
}
