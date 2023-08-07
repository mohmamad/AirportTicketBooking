using Airport.DAL.Repositories;

namespace Airport.BLL.FlightFilter
{
    public class FlightPrice : FlightIFilter
    {
        private List<int> price;

        public FlightPrice(List<int> price)
        {
            this.price = price;
        }
        public List<Flight> Filter(List<Flight> objectTofilter)
        {
            for(int i = 0; i < price.Count; i++) 
            {
                objectTofilter = objectTofilter.Where(obj => obj.FlightPrice[i] == price[i]).ToList();
            }
            return objectTofilter;
        }
    }
}
