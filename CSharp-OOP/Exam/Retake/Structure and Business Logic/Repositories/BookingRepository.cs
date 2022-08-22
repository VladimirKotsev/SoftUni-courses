namespace BookingApp.Repositories
{
    using System;

    using Models.Bookings.Contracts;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> books;

        public BookingRepository()
        {
            this.books = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            this.books.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return this.books.AsReadOnly();
        }

        public IBooking Select(string criteria)
        {
            return this.books.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);
        }
    }
}
