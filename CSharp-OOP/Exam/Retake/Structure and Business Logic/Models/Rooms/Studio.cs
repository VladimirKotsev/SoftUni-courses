namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int StudioRoomCapacity = 4;
        public Studio() 
            : base(StudioRoomCapacity)
        {

        }
    }
}
