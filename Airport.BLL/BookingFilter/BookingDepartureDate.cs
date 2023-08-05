using Airport.DAL.Repositories;

namespace Airport.BLL.BookingFilter
{
    public class BookingDepartureDate : BookingIFilter
    {
        private DateTime departureDate;

        public BookingDepartureDate(DateTime departureDate)
        {
            this.departureDate = departureDate;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.DepartureDate == departureDate).ToList();
        }
    }
}
