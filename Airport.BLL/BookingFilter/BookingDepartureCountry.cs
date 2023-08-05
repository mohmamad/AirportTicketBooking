using Airport.DAL.Repositories;

namespace Airport.BLL.BookingFilter
{
    public class BookingDepartureCountry : BookingIFilter
    {
        private string departureCountry;

        public BookingDepartureCountry(string departureCountry)
        {
            this.departureCountry = departureCountry;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.DepartureCountry == departureCountry).ToList();
        }
    }
}
