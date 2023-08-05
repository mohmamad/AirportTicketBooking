using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public class FlightComposite : FlightIFilter
    {
        private List<FlightIFilter> children = new List<FlightIFilter>();

        public void add(FlightIFilter filter)
        {
            children.Add(filter);
        }
        public void remove(FlightIFilter filter)
        {
            children.Remove(filter);
        }

        public List<Flight> Filter(List<Flight> ObjToFilter)
        {
            foreach (FlightIFilter child in children)
            {
                ObjToFilter = child.Filter(ObjToFilter);
            }
            return ObjToFilter;
        }
        
    }
}
