using Airport.DAL.Repositories;

namespace Airport.BLL.BookingFilter
{
    public class BookingDestinationCountry : BookingIFilter
    {
        private string destinationCountry;

        public BookingDestinationCountry(string destinationCountry)
        {
            this.destinationCountry = destinationCountry;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.DestinationCountry == destinationCountry).ToList();
        }
    }
}
