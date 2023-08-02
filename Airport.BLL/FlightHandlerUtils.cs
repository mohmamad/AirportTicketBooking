using Airport.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL
{
    public static class FlightHandlerUtils
    {
        public static string ConvertToCSV(FlightData flightData)
        {
            StringBuilder flight = new StringBuilder();
            flight.Append(flightData.FlightId + ",");
            flight.Append(flightData.DepartureCountry + ",");
            flight.Append(flightData.DestinationCountry + ",");
            flight.Append(flightData.DepartureDate + ",");
            flight.Append(flightData.DepartureAirport + ",");
            flight.Append(flightData.ArrivalAirport + ",");
            for(int i = 0; i < flightData.Class.Count; i++)
            {
                flight.Append(flightData.Class[i] + ",");
                flight.Append(flightData.FlightPrice[i] + ",");
            }
            return flight.ToString();
        }
      
    }
}
