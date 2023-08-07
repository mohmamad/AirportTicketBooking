using Airport.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.Utilities
{
    public static class FlightHandlerUtils
    {


        /// <summary>
        /// converts the flight entity to CSV format.
        /// </summary>
        public static string ConvertToCSV(Flight flightData)
        {
            StringBuilder flight = new StringBuilder();
            flight.Append(flightData.FlightId + ",");
            flight.Append(flightData.DepartureCountry + ",");
            flight.Append(flightData.DestinationCountry + ",");
            flight.Append(flightData.DepartureDate + ",");
            flight.Append(flightData.DepartureAirport + ",");
            flight.Append(flightData.ArrivalAirport);
            for (int i = 0; i < flightData.Class.Count; i++)
            {
                flight.Append("," + flightData.Class[i] + ",");
                flight.Append(flightData.FlightPrice[i]);
            }
            return flight.ToString();
        }


        /// <summary>
        /// Convert from CSV format to flight entity
        /// </summary>
        public static Flight ConvertToFlight(string flight)
        {
            List<string> classes = new List<string>();
            List<int> prices = new List<int>();
            try
            {
                classes.Clear();
                for (int i = 6; i < flight.Split(",").Length; i += 2)
                {
                    if(flight.Split(",")[i] != " ")
                        classes.Add(flight.Split(",")[i]);
                    if (flight.Split(",")[i + 1] != " ")
                        prices.Add(int.Parse(flight.Split(",")[i + 1]));
                }

                return new Flight
                {
                    FlightId = int.Parse(flight.Split(',')[0]),
                    DepartureCountry = flight.Split(",")[1],
                    DestinationCountry = flight.Split(",")[2],
                    DepartureDate = DateTime.Parse(flight.Split(",")[3]),
                    DepartureAirport = flight.Split(",")[4],
                    ArrivalAirport = flight.Split(",")[5],
                    Class = classes,
                    FlightPrice = prices
                };
            }
            catch (Exception)
            {
                classes.Clear();
                //56 78 910
                for (int i = 5; i < flight.Split(",").Length; i += 2)
                {
                    try
                    {
                        if (flight.Split(",")[i + 1] != " ")
                            prices.Add(int.Parse(flight.Split(",")[i + 1]));
                        if (flight.Split(",")[i] != " ")
                            classes.Add(flight.Split(",")[i]);
                    }
                    catch (Exception) { }
                    
                }
                DateTime departureDate = new DateTime();
                try
                {
                    departureDate = DateTime.Parse(flight.Split(",")[2]);
                }catch (Exception) { }
                
                return new Flight
                {
                    DepartureCountry = flight.Split(",")[0],
                    DestinationCountry = flight.Split(",")[1],
                    DepartureDate = departureDate,
                    DepartureAirport = flight.Split(",")[3],
                    ArrivalAirport = flight.Split(",")[4],
                    Class = classes,
                    FlightPrice = prices
                };
            }


        }

    }
}
