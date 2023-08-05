using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public class FlightDestinationCountry : FlightIFilter
    {
        private string destinationCountry;

        public FlightDestinationCountry(string destinationCountry)
        {
            this.destinationCountry = destinationCountry;
        }
        public List<Flight> Filter(List<Flight> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.DestinationCountry == destinationCountry).ToList();
        }
    }
}
