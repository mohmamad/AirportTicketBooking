using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public class FlightDepartureAirport : FlightIFilter
    {
        private string departureAirport;

        public FlightDepartureAirport(string departureAirport)
        {
            this.departureAirport = departureAirport;
        }
        public List<Flight> Filter(List<Flight> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.DepartureAirport == departureAirport).ToList();
        }
    }
}
