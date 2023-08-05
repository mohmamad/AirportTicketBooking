using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DAL
{
    public static class FlightRepositoryUtils
    {
        /// <summary>
        /// convert Flight to CSV format
        /// </summary>
        public static string ConvertToCSV(Flight flight)
        {
            StringBuilder userData = new StringBuilder();
            userData.Append(flight.FlightId + ",");
            userData.Append(flight.DepartureCountry + ",");
            userData.Append(flight.DestinationCountry + ",");
            userData.Append(flight.DepartureDate + ",");
            userData.Append(flight.DepartureAirport + ",");
            userData.Append(flight.ArrivalAirport);
            for(int i = 0; i < flight.Class.Count; i++)
            {
                userData.Append("," + flight.Class[i] + ",");
                userData.Append(flight.FlightPrice[i]);
            }
        
            return userData.ToString();

        }
    }
}
