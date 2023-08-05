using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.DAL.Interfaces;
using Airport.DAL.Utilities;

namespace Airport.DAL.Repositories
{
    public class Booking
    {
        public int BookingId; public string FlightId; public int Price; public string DepartureCountry
        ; public string DestinationCountry; public DateTime DepartureDate; public string DepartureAirport
        ; public string ArrivalAirport; public string PassengerUserName; public string Class;
    }
    public class BookingRepository : IBookingRepository
    {
        const string bookingsFilePath = @"C:\Users\GoldenTech\Desktop\study\intern\C#\exercise\Airprot\dataFiles\bookingsFile.txt";

        public string[] GetAllBookings()
        {
            List<string> emptyAllBookings = new List<string>();
            string[] allBookings = emptyAllBookings.ToArray();
            if (File.Exists(bookingsFilePath)) { allBookings = File.ReadAllLines(bookingsFilePath); }

            return allBookings;
        }

        public void AddBooking(Booking bookingInfo)
        {
            int bookingId = 1;
            //to generate the booking ID

            if (File.Exists(bookingsFilePath))
            {
                bookingId = GetAllBookings().Length;
            }


            bookingInfo.BookingId = bookingId;
            File.AppendAllText(bookingsFilePath, BookingRepositoryUtils.ConvertToCSV(bookingInfo) + "\r\n");
        }


        public void UpdateBooking(Booking oldBooking, Booking newBooking)
        {
            string[] allBookings = GetAllBookings();

            //finds the index of the old booking to midifay its value to the new booking value.
            allBookings[allBookings.ToList().IndexOf(BookingRepositoryUtils.ConvertToCSV(oldBooking))]
                                                    = BookingRepositoryUtils.ConvertToCSV(newBooking);
            //delete file to update its data.
            File.Delete(bookingsFilePath);

            //insert the new booking value to file.
            foreach (var booking in allBookings)
                File.AppendAllText(bookingsFilePath, booking + "\r\n");

        }

        public void DeleteBooking(int bookingId)
        {
            string[] allBookings = GetAllBookings();
            List<string> bookings = allBookings.ToList();
            try
            {
                string bookingToRemove = allBookings.Where(booking => int.Parse(booking.Split(',')[0]) == bookingId).ToList()[0];
                bookings.Remove(bookingToRemove);
                //delete file to update its data.
                File.Delete(bookingsFilePath);

                //insert the new booking value to file.
                foreach (var booking in bookings)
                    File.AppendAllText(bookingsFilePath, booking + "\r\n");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
