namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int DoubleBedRoomCapacity = 2;

        public DoubleBed() 
            : base(DoubleBedRoomCapacity)
        {

        }
    }
}
