using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.DAL.Repositories;

namespace Airport.DAL.Interfaces
{
    public interface IBookingRepository
    {
        /// <summary>
        /// add a new booking.
        /// </summary>
        public void AddBooking(Booking bookingInfo);

        /// <summary>
        /// Update a booking by taking the old booking values and inserting the new booking values.
        /// </summary>
        public void UpdateBooking(Booking oldBookingInfo, Booking newBookingInfo);

        /// <summary>
        /// Returns a list of all the bookings data
        /// </summary>
        public string[] GetAllBookings();

        /// <summary>
        /// Delete a booking data
        /// </summary>
        public void DeleteBooking(int bookingId);
    }
}
