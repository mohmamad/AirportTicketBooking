using Airport.BLL.BookingFilter;
using Airport.BLL.Interfaces;
using Airport.BLL.Utilities;
using Airport.DAL.Interfaces;
using Airport.DAL.Repositories;
using System.Linq;
using System.Text;

namespace Airport.BLL.Handlers

{
    public class BookingHandler : IBookingHandler
    {
        IBookingRepository Booking = new BookingRepository();
        BookingComposite filterBy = new BookingComposite();
        public void Book(string bookingInfo , string userName)
        {
            //insert the correct user name to the booking info
            StringBuilder newBook = new StringBuilder();
            newBook.Append(bookingInfo.Split(',')[0] + ","); newBook.Append(bookingInfo.Split(',')[1] + ",");
            newBook.Append(bookingInfo.Split(',')[2] + ","); newBook.Append(bookingInfo.Split(',')[3] + ",");
            newBook.Append(bookingInfo.Split(',')[4] + ","); newBook.Append(bookingInfo.Split(',')[5] + ",");
            newBook.Append(bookingInfo.Split(',')[6] + ","); newBook.Append(userName + ",");
            newBook.Append(bookingInfo.Split(',')[7]);
            
            Booking.AddBooking(BookingHandlerUtils.ConvertToBookingData(newBook.ToString().Split(',')));
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

        public string Update(int bookingId, string newclass)
        {
            FlightsRepository flightsRepository = new FlightsRepository();
            List<Flight> flights = new List<Flight>();
            string message = "";
            Booking bookingToUpdate = new Booking();
            Booking newBooking = new Booking();
            List<Booking> bookings = new List<Booking>();
            foreach(string booking in Booking.GetAllBookings())
            {
                bookings.Add(BookingHandlerUtils.ConvertToBookingData(booking.Split(',')));
            }
            try
            {
                bookingToUpdate = bookings.Where(booking => booking.BookingId == bookingId).ToList()[0];
            }catch (Exception ex) { message = "Booking not found!"; return message;}
            foreach (string flightInfo in flightsRepository.GetAllFlights())
            {
                flights.Add(FlightHandlerUtils.ConvertToFlight(flightInfo));
            }

            //to change the price according to the new class
            Flight flight = flights.Where(flight => flight.FlightId == int.Parse(bookingToUpdate.FlightId)).ToList()[0];
            newBooking.DepartureCountry = bookingToUpdate.DepartureCountry;
            newBooking.DestinationCountry = bookingToUpdate.DestinationCountry;
            newBooking.DepartureDate = bookingToUpdate.DepartureDate;
            newBooking.DepartureAirport = bookingToUpdate.DepartureAirport;
            newBooking.ArrivalAirport = bookingToUpdate.ArrivalAirport;
            newBooking.PassengerUserName = bookingToUpdate.PassengerUserName;
            newBooking.FlightId = bookingToUpdate.FlightId;
            newBooking.BookingId = bookingToUpdate.BookingId;
            newBooking.Price = flight.FlightPrice[flight.Class.IndexOf(newclass)];
            newBooking.Class = newclass;
            
            Booking.UpdateBooking(bookingToUpdate, newBooking); message = "Update was successful!";
            

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
