using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public class FlightDepartureCountry : FlightIFilter
    {
        private string departureCountry;

        public FlightDepartureCountry(string departureCountry)
        {
            this.departureCountry = departureCountry;
        }
        public List<Flight> Filter(List<Flight> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.DepartureCountry == departureCountry).ToList();
        }
    }
}
