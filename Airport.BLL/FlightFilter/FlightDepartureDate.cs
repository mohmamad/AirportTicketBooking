using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public class FlightDepartureDate : FlightIFilter
    {
        private DateTime departureDate;

        public FlightDepartureDate(DateTime departureDate)
        {
            this.departureDate = departureDate;
        }
        public List<Flight> Filter(List<Flight> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.DepartureDate == departureDate).ToList();
        }
    }
}
