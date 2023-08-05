using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public class FlightArrivalAirport : FlightIFilter
    {
        private string arrivalAirport;

        public FlightArrivalAirport(string arrivalAirport)
        {
            this.arrivalAirport = arrivalAirport;
        }
        public List<Flight> Filter(List<Flight> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.ArrivalAirport == arrivalAirport).ToList();
        }
    }
}
