using Airport.DAL.Repositories;

namespace Airport.BLL.BookingFilter
{
    public class BookingArrivalAirport : BookingIFilter
    {
        private string arrivalAirport;

        public BookingArrivalAirport(string arrivalAirport)
        {
            this.arrivalAirport = arrivalAirport;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.ArrivalAirport == arrivalAirport).ToList();
        }
    }
}
