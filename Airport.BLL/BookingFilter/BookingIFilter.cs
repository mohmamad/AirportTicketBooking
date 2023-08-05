using Airport.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.BookingFilter
{
    public interface BookingIFilter
    {
        /// <summary>
        /// Filters a List Bookings by a given field
        /// </summary>
        /// <param name="BookingsToFilter"></param>
        /// <returns>A list of all the found Bookings</returns>
        public List<Booking> Filter(List<Booking> BookingsToFilter);
    }
}
