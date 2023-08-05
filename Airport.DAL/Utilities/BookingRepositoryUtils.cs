using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.DAL.Repositories;

namespace Airport.DAL.Utilities
{
    public static class BookingRepositoryUtils
    {
        /// <summary>
        /// convert Booking to CSV format
        /// </summary>
        public static string ConvertToCSV(Booking booking)
        {
            StringBuilder aBooking = new StringBuilder();
            aBooking.Append(booking.BookingId + ",");
            aBooking.Append(booking.FlightId + ",");
            aBooking.Append(booking.Price + ",");
            aBooking.Append(booking.DepartureCountry + ",");
            aBooking.Append(booking.DestinationCountry + ",");
            aBooking.Append(booking.DepartureDate + ",");
            aBooking.Append(booking.DepartureAirport + ",");
            aBooking.Append(booking.ArrivalAirport + ",");
            aBooking.Append(booking.PassengerUserName + ",");
            aBooking.Append(booking.Class);

            return aBooking.ToString();
        }

    }
}
