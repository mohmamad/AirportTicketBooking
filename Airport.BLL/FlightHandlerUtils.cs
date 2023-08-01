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
            flight.AppendLine(flightData.FlightId + ",");
            flight.AppendLine(flightData.DepartureCountry + ",");
            flight.AppendLine(flightData.DestinationCountry + ",");
            flight.AppendLine(flightData.DepartureDate + ",");
            flight.AppendLine(flightData.DepartureAirport + ",");
            flight.AppendLine(flightData.ArrivalAirport + ",");
            flight.AppendLine(flightData.Class[0] + ",");
            flight.AppendLine(flightData.FlightPrice[0] + ",");
            flight.AppendLine(flightData.Class[1] + ",");
            flight.AppendLine(flightData.FlightPrice[1] + ",");
            flight.AppendLine(flightData.Class[2] + ",");
            flight.AppendLine(flightData.FlightPrice[2] + ",");
            return flight.ToString();
        }
      
    }
}
