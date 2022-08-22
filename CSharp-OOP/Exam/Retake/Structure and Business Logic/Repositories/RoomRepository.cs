namespace BookingApp.Repositories
{
    using System;

    using Models.Rooms.Contracts;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return this.rooms.AsReadOnly();   
        }

        public IRoom Select(string criteria)
        {
            return this.rooms.FirstOrDefault(x => x.GetType().Name == criteria);
        }
    }
}
