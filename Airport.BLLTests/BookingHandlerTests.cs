using Airport.BLL.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLLTests
{
    [TestClass]
    public class BookingHandlerTests
    {
        BookingHandler booking = new BookingHandler();
        [TestMethod]
        public void BookAndViewUserBookingTest()
        {
            //--arrange
            booking.Book("1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,economy");
            string expected = "0,1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,economy";
            //--act
            List<string> actual = booking.ViewAllUserBookings("mohamad");
            //--assert
            Assert.AreEqual(expected , actual[0]);
        }

        [TestMethod]
        public void BookingSearchTest()
        {
            //--arrange 
            string expected = "1,1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,economy";
            //--act
            List<string> actual = booking.Search("1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,economy");
            //--assert
            Assert.AreEqual (expected , actual[0]);
        }
        [TestMethod]
        public void BookingUpdateTest()
        {
            //--arrange
            string expected = "1,1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,economy";
            booking.Update("1,1,100,palestine,china,8/10/2023 12:00:00 AM,telitbees,lala,mohamad,Business", expected);
            //--act
            List<string> actual = booking.ViewAllUserBookings("mohamad");
            //--assert
            Assert.AreEqual(expected, actual[1]);
        }

        [TestMethod]
        public void BookingDeleteTest() 
        {
            //--arrange
            int expected = 1;
            booking.DeleteBooking(1);
            //--act
            List<string> actual = booking.ViewAllUserBookings("mohamad");
            //--assert
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
