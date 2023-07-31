using Airport.DAL;
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
            bookingRepository.AddBooking(bookingInfo);
            string exp = "1,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,economy";
            //--act
            List<BookingData> actual = new List<BookingData>();
            actual = bookingRepository.GetAllBookings();
            //--assert
            foreach (BookingData act in actual)
            {
                Assert.AreEqual(act.BookingId, int.Parse(exp.Split(',')[0]));
                Assert.AreEqual(act.FlightId, exp.Split(',')[1]);
                Assert.AreEqual(act.Price, int.Parse(exp.Split(',')[2]));
                Assert.AreEqual(act.DepartureCountry, exp.Split(',')[3]);
                Assert.AreEqual(act.DestinationCountry, exp.Split(',')[4]);
                Assert.AreEqual(act.DepartureDate, DateTime.Parse(exp.Split(',')[5]));
                Assert.AreEqual(act.DepartureAirport, exp.Split(',')[6]);
                Assert.AreEqual(act.ArrivalAirport, exp.Split(',')[7]);
                Assert.AreEqual(act.PassengerUserName, exp.Split(',')[8]);
                Assert.AreEqual(act.Class, exp.Split(',')[9]);
            }
        }

        [TestMethod]
        public void UpdateBookingTest()
        {
            //--arrange
            const string oldBookingInfo = "2,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,economy";
            const string newBookingInfo = "2,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,business";
            BookingRepository bookingRepository = new BookingRepository();
            bookingRepository.UpdateBooking(oldBookingInfo, newBookingInfo);
            string exp = "2,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,business";

            //--act
            List<BookingData> actual = new List<BookingData>();
            actual = bookingRepository.GetAllBookings();
            //--assert
            foreach (BookingData act in actual)
            {
                Assert.AreEqual(act.BookingId, int.Parse(exp.Split(',')[0]));
                Assert.AreEqual(act.FlightId, exp.Split(',')[1]);
                Assert.AreEqual(act.Price, int.Parse(exp.Split(',')[2]));
                Assert.AreEqual(act.DepartureCountry, exp.Split(',')[3]);
                Assert.AreEqual(act.DestinationCountry, exp.Split(',')[4]);
                Assert.AreEqual(act.DepartureDate, DateTime.Parse(exp.Split(',')[5]));
                Assert.AreEqual(act.DepartureAirport, exp.Split(',')[6]);
                Assert.AreEqual(act.ArrivalAirport, exp.Split(',')[7]);
                Assert.AreEqual(act.PassengerUserName, exp.Split(',')[8]);
                Assert.AreEqual(act.Class, exp.Split(',')[9]);
            }
        }

        [TestMethod]
        public void DeleteBookingTest()
        {
            //--arrange
          //  const string oldBookingInfo = "1,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,economy";
            //const string newBookingInfo = "1,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,business";
            BookingRepository bookingRepository = new BookingRepository();
            bookingRepository.DeleteBooking("1");
            string exp = "2,1,100,palestine,china,8/10/2023 12:00,telitbees,lala,mohamad,economy";

            //--act
            List<BookingData> actual = new List<BookingData>();
            actual = bookingRepository.GetAllBookings();
            //--assert
            foreach (BookingData act in actual)
            {
                Assert.AreEqual(act.BookingId, int.Parse(exp.Split(',')[0]));
                Assert.AreEqual(act.FlightId, exp.Split(',')[1]);
                Assert.AreEqual(act.Price, int.Parse(exp.Split(',')[2]));
                Assert.AreEqual(act.DepartureCountry, exp.Split(',')[3]);
                Assert.AreEqual(act.DestinationCountry, exp.Split(',')[4]);
                Assert.AreEqual(act.DepartureDate, DateTime.Parse(exp.Split(',')[5]));
                Assert.AreEqual(act.DepartureAirport, exp.Split(',')[6]);
                Assert.AreEqual(act.ArrivalAirport, exp.Split(',')[7]);
                Assert.AreEqual(act.PassengerUserName, exp.Split(',')[8]);
                Assert.AreEqual(act.Class, exp.Split(',')[9]);
            }
        }


    }
}
