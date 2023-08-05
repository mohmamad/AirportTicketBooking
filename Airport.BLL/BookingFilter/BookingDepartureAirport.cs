using Airport.DAL.Repositories;

namespace Airport.BLL.BookingFilter
{
    public class BookingDepartureAirport : BookingIFilter
    {
        private string departureAirport;

        public BookingDepartureAirport(string departureAirport)
        {
            this.departureAirport = departureAirport;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.DepartureAirport == departureAirport).ToList();
        }
    }
}
