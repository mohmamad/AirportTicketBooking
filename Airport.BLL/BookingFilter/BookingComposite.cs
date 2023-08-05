using Airport.DAL.Repositories;

namespace Airport.BLL.BookingFilter
{
    public class BookingComposite : BookingIFilter
    {
        private List<BookingIFilter> children = new List<BookingIFilter>();

        public void add(BookingIFilter filter)
        {
            children.Add(filter);
        }
        public void remove(BookingIFilter filter)
        {
            children.Remove(filter);
        }

        public List<Booking> Filter(List<Booking> ObjToFilter)
        {
            foreach (BookingIFilter child in children)
            {
                ObjToFilter = child.Filter(ObjToFilter);
            }
            return ObjToFilter;
        }
        
    }
}
