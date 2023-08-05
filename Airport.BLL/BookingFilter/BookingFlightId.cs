using Airport.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.BookingFilter
{
    public class BookingFlightId : BookingIFilter
    {
        private string flightId;

        public BookingFlightId(string flightId)
        {
            this.flightId = flightId;
        }
        public List<Booking> Filter(List<Booking> objectTofilter)
        {
            return objectTofilter.Where(obj => obj.FlightId == flightId).ToList();
        }
    }
}
