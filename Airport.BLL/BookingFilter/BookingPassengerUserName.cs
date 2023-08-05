using Airport.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.BookingFilter
{
    public class BookingPassengerUserName : BookingIFilter
    {
        private string UserName;

        public BookingPassengerUserName(string UserName)
        {
            this.UserName = UserName;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.PassengerUserName == UserName).ToList();
        }
    }
}
