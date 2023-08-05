using Airport.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortTests
{
    [TestClass]
    public class BookingRepositoryTests
    {
        [TestMethod]
        public void AddNewBookingTest()
        {
            //--arrange
            const string bookingInfo = "1,100,palestine,china,August 10 2023 12:00,telitbees,lala,mohamad,economy";
            BookingRepository bookingRepository = new BookingRepository();
            Booking booking = new Booking
            {
                FlightId = "1",
                Price = 100,
                DepartureCountry = "palestine",
                DestinationCountry = "china",
                DepartureDate = DateTime.Parse("8/10/2023"),
                DepartureAirport = "telitbees",
                ArrivalAirport = "lala",
                PassengerUserName = "mohamad",
                Class = "economy"
            };

            bookingRepository.AddBooking(booking);
            string exp = "1,1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,economy";
            //--act
            
            string[] actual = bookingRepository.GetAllBookings();
            //--assert
            Assert.AreEqual(actual[0], exp);
        }

        [TestMethod]
        public void UpdateBookingTest()
        {
            //--arrange
 
            BookingRepository bookingRepository = new BookingRepository();
            Booking oldBooking = new Booking
            {
                BookingId = 1,
                FlightId = "1",
                Price = 100,
                DepartureCountry = "palestine",
                DestinationCountry = "china",
                DepartureDate = DateTime.Parse("8/10/2023"),
                DepartureAirport = "telitbees",
                ArrivalAirport = "lala",
                PassengerUserName = "mohamad",
                Class = "business"
            };

            Booking newBooking = new Booking
            {
                BookingId = 1,
                FlightId = "1",
                Price = 100,
                DepartureCountry = "palestine",
                DestinationCountry = "china",
                DepartureDate = DateTime.Parse("8/10/2023"),
                DepartureAirport = "telitbees",
                ArrivalAirport = "lala",
                PassengerUserName = "mohamad",
                Class = "economy"
            };
            bookingRepository.UpdateBooking(oldBooking, newBooking);
            string exp = "1,1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,economy";

            //--act
            
            string[] actual = bookingRepository.GetAllBookings();
            //--assert
           Assert.AreEqual(actual[0], exp);
        }

        [TestMethod]
        public void DeleteBookingTest()
        {
            //--arrange
            //  const string oldBookingInfo = "1,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,economy";
            //const string newBookingInfo = "1,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,business";
            BookingRepository bookingRepository = new BookingRepository();
            bookingRepository.DeleteBooking(1);
            string exp = "2,1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,economy";

            //--act
            string[] actual = bookingRepository.GetAllBookings();
            //--assert
            Assert.AreEqual(exp, actual[0]);
        }


    }
}
