using Airport.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.Utilities
{
    public static class BookingHandlerUtils
    {
        public static Booking ConvertToBookingData(string[] bookingData)
        {
            try
            {
                return new Booking
                {
                    BookingId = int.Parse(bookingData[0]),
                    FlightId = bookingData[1],
                    Price = int.Parse(bookingData[2]),
                    DepartureCountry = bookingData[3],
                    DestinationCountry = bookingData[4],
                    DepartureDate = DateTime.Parse(bookingData[5]),
                    DepartureAirport = bookingData[6],
                    ArrivalAirport = bookingData[7],
                    PassengerUserName = bookingData[8],
                    Class = bookingData[9]
                };
            }catch (Exception ex)
            {
                return new Booking
                {
                    FlightId = bookingData[0],
                    Price = int.Parse(bookingData[1]),
                    DepartureCountry = bookingData[2],
                    DestinationCountry = bookingData[3],
                    DepartureDate = DateTime.Parse(bookingData[4]),
                    DepartureAirport = bookingData[5],
                    ArrivalAirport = bookingData[6],
                    PassengerUserName = bookingData[7],
                    Class = bookingData[8]
                };
            }
        }


        /// <summary>
        /// converts the booking entity to CSV format.
        /// </summary>
        public static string ConvertToCSV(Booking bookingData)
        {
            StringBuilder booking = new StringBuilder();
            booking.Append(bookingData.BookingId + ",");
            booking.Append(bookingData.FlightId + ",");
            booking.Append(bookingData.Price + ",");
            booking.Append(bookingData.DepartureCountry + ",");
            booking.Append(bookingData.DestinationCountry + ",");
            booking.Append(bookingData.DepartureDate + ",");
            booking.Append(bookingData.DepartureAirport + ",");
            booking.Append(bookingData.ArrivalAirport + ",");
            booking.Append(bookingData.PassengerUserName + ",");
            booking.Append(bookingData.Class);

            return booking.ToString();
        }
    }
}
