using Airport.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL
{
    public class FlightHandler
    {
        FlightsRepository flights = new FlightsRepository();
        Validator validate = new Validator();
        public List<string> ViewAllValidFlights()
        {
            List<FlightData> flight = flights.GetAllFlights().Where(flight => flight.DepartureDate >= DateTime.Now).ToList();
            List<string> flightsCSVFormat = new List<string>();
            foreach(FlightData flightData in flight)
            {
                flightsCSVFormat.Add(FlightHandlerUtils.ConvertToCSV(flightData));
            }
            return flightsCSVFormat;
        }

        public List<string> AddFlight(string CSVFilePath)
        {
            bool isValid = true;
            List<string> errorMessages = new List<string>();

            if(!File.Exists(CSVFilePath)) {errorMessages.Add("File Not Found!"); return errorMessages; }

            string[] newFlights = File.ReadAllLines(CSVFilePath);
            
            foreach (string flight in newFlights)
            {
                string message = validate.ValidateFlight(flight);

                if (message != "Valid flight") 
                {isValid = false; errorMessages.Add($"{message}{newFlights.ToList().IndexOf(flight) + 1}");}
               
            }
            if(!isValid) return errorMessages;

            errorMessages.Add("Flights added successfully!");
            foreach (string flight in newFlights)
            {
                flights.AddFlight(flight);
            }
            return errorMessages;
        }

        public List<string> Search(string flightToSearch)
        {
            List<string> CSVfoundFlights = new List<string>();  
            string[] flightData = flightToSearch.Split(',');
           //, ,pasd, , , , , , , , ,
            List<FlightData> foundFlights = flights.GetAllFlights().Where(flight => flight.DepartureCountry == flightData[0] 
            || flight.DestinationCountry == flightData[1] || flight.DepartureDate.ToString() == flightData[2]
            || flight.DepartureAirport == flightData[3] || flight.ArrivalAirport == flightData[4] 
            || flight.Class[0] == flightData[5] || flight.FlightPrice[0].ToString() == flightData[6]
            || flight.Class[1] == flightData[7] || flight.FlightPrice[1].ToString() == flightData[8]
            || flight.Class[2] == flightData[9] || flight.FlightPrice[2].ToString() == flightData[10]).ToList();

            foreach(FlightData flight in foundFlights)
            {
                CSVfoundFlights.Add(FlightHandlerUtils.ConvertToCSV(flight));
            }
            return CSVfoundFlights;
        }
    }
}
