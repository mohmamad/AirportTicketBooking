using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public class FlightClass : FlightIFilter
    {
        private List<string> Class;

        public FlightClass(List<string> flightClass)
        {
            this.Class = flightClass;
        }
        public List<Flight> Filter(List<Flight> objectTofilter)
        {

            for (int i = 0; i < Class.Count ; i++)
            {
                objectTofilter = objectTofilter.Where(obj =>obj.Class.Count == Class.Count && obj.Class[i] == Class[i]).ToList();
            }
            return objectTofilter;
        }
    }
}
