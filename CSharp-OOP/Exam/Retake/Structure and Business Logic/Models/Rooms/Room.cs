namespace BookingApp.Models.Rooms
{
    using System;

    using Contracts;
    using Utilities.Messages;
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        public int BedCapacity
        {
            get { return bedCapacity; }
            private set { bedCapacity = value; }
        }

        private double pricePerNight;
        public double PricePerNight
        {
            get { return pricePerNight; }
            private set 
            { 
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                pricePerNight = value; 
            }
        }

        protected Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = 0;
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
