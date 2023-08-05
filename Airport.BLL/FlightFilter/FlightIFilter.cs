using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public interface FlightIFilter
    {
        /// <summary>
        /// Filters a list of flights by a given field
        /// </summary>
        /// <param name="FlightTofilter"></param>
        /// <returns>A list of all the found flights</returns>
        public List<Flight> Filter(List<Flight> FlightTofilter);
    }
}
