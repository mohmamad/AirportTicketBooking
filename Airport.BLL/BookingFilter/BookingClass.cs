using Airport.DAL.Repositories;

namespace Airport.BLL.BookingFilter
{
    public class BookingClass : BookingIFilter
    {
        private string FlightClass;

        public BookingClass(string flightClass)
        {
            this.FlightClass = flightClass;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {

            objectTofilter = objectTofilter.Where(obj => obj.Class == FlightClass).ToList();
            return objectTofilter;
        }
    }
}
