namespace BookingApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BookingApp.Models.Hotels.Contacts;
    using Contracts;
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            this.hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return this.hotels.AsReadOnly();
        }

        public IHotel Select(string criteria)
        {
            return this.hotels.FirstOrDefault(x => x.FullName == criteria);
        }
    }
}
