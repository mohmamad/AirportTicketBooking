using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.Interfaces
{
    public interface IBookingHandler
    {
        /// <summary>
        /// books a flight and adds a new booking info to booking file
        /// </summary>
        public void Book(string flightInfo , string userName);

        /// <summary>
        /// filters the bookings (Only For The Manager)
        /// </summary>
        public List<string> Search(string bookingInfo);

        /// <summary>
        /// updates the booking class returns an error message
        /// </summary>
        public string Update(int bookingId, string newClass);

        /// <summary>
        /// returns a list of all the users bookings
        /// </summary>
        public List<string> ViewAllUserBookings(string userName);

        /// <summary>
        /// deletes the booking with the given booking ID
        /// </summary>
        public void DeleteBooking(int bookingId);


    }
}
