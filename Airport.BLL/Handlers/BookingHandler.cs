using Airport.BLL.BookingFilter;
using Airport.BLL.Interfaces;
using Airport.BLL.Utilities;
using Airport.DAL.Interfaces;
using Airport.DAL.Repositories;

namespace Airport.BLL.Handlers

{
    public class BookingHandler : IBookingHandler
    {
        IBookingRepository Booking = new BookingRepository();
        BookingComposite filterBy = new BookingComposite();
        public void Book(string bookingInfo)
        {
            Booking.AddBooking(BookingHandlerUtils.ConvertToBookingData(bookingInfo.Split(',')));
        }

        public List<string> Search(string bookingInfo)
        {
            List<string> CSVFoundBookings = new List<string>();
            //TODO search method implementation
            string[] bookingData = bookingInfo.Split(',');
            List<Booking> foundBookings = new List<Booking>();

            foreach (string booking in Booking.GetAllBookings())
            {
                foundBookings.Add(BookingHandlerUtils.ConvertToBookingData(booking.Split(',')));
            }

            if (bookingData[0] != " ")
                filterBy.add(new BookingFlightId(bookingData[0]));
            if (bookingData[1] != " ")
                filterBy.add(new BookingPrice(int.Parse(bookingData[1])));
            if (bookingData[2] != " ")
                filterBy.add(new BookingDepartureCountry(bookingData[2]));
            if (bookingData[3] != " ")
                filterBy.add(new BookingDestinationCountry(bookingData[3]));
            if (bookingData[4] != " ")
                filterBy.add(new BookingDepartureDate(DateTime.Parse(bookingData[4])));
            if (bookingData[5] != " ")
                filterBy.add(new BookingDepartureAirport(bookingData[5]));
            if (bookingData[6] != " ")
                filterBy.add(new BookingArrivalAirport(bookingData[6]));
            if (bookingData[7] != " ")
                filterBy.add(new BookingPassengerUserName(bookingData[7]));
            if (bookingData[8] != " ")
                filterBy.add(new BookingClass(bookingData[8]));

            foundBookings = filterBy.Filter(foundBookings);

            foreach (Booking booking in foundBookings)
            {
                CSVFoundBookings.Add(BookingHandlerUtils.ConvertToCSV(booking));
            }
            return CSVFoundBookings;
        }

        public string Update(string oldBookingInfo, string newBookingInfo)
        {
            FlightHandler flight = new FlightHandler();
            string message = "";
            string[] newBooking = newBookingInfo.Split(',');

            if (!Booking.GetAllBookings().ToList().Contains(oldBookingInfo))
                message = "Booking not found!";
            else
            {
                Booking.UpdateBooking(BookingHandlerUtils.ConvertToBookingData(oldBookingInfo.Split(','))
            , BookingHandlerUtils.ConvertToBookingData(newBookingInfo.Split(','))); message = "Update was successful!";
            }

            return message;
        }

        public List<string> ViewAllUserBookings(string userName)
        {
            List<Booking> bookings = new List<Booking>();
            List<string> foundUserBookings = new List<string>();

            foreach (string booking in Booking.GetAllBookings())
            {
                bookings.Add(BookingHandlerUtils.ConvertToBookingData(booking.Split(',')));
            }
            bookings = bookings.Where(booking => booking.PassengerUserName == userName).ToList();
            foreach (Booking booking in bookings)
            {
                foundUserBookings.Add(BookingHandlerUtils.ConvertToCSV(booking));
            }

            return foundUserBookings;
        }

        public void DeleteBooking(int bookingId)
        {
            Booking.DeleteBooking(bookingId);
        }

    }
}
