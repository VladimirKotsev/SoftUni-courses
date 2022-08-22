namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int ApartmentRoomCapacity = 6;
        public Apartment() 
            : base(ApartmentRoomCapacity)
        {

        }
    }
}
