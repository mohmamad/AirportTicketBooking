using Airport.DAL.Repositories;

namespace Airport.BLL.BookingFilter
{
    public class BookingPrice : BookingIFilter
    {
        private int price;

        public BookingPrice(int price)
        {
            this.price = price;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {
            
            objectTofilter = objectTofilter.Where(obj => obj.Price == price).ToList();
          
            return objectTofilter;
        }
    }
}
