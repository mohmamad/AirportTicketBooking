using Airport.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL
{
    public class FlightHandler : IFlightHandler
    {
        FlightsRepository flights = new FlightsRepository();
        Validator validate = new Validator();

        public List<string> ViewAllValidFlights()
        {
            List<FlightData> flight = flights.GetAllFlights().Where(flight => flight.DepartureDate >= DateTime.Now).Select(flight => flight).ToList();
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
            //TODO insert flight info to a dictionry or to an object to improve code readablity
            //, ,pasd, , , , , , , , ,
            List<FlightData> foundFlights = flights.GetAllFlights();
            if (flightData[0] != " ")
                foundFlights = foundFlights.Where(flight => flight.DepartureCountry == flightData[0]).ToList();
            if (flightData[1] != " ")
                foundFlights = foundFlights.Where(flight => flight.DestinationCountry == flightData[1]).ToList();
            if (flightData[2] != " ")
                foundFlights = foundFlights.Where(flight => flight.DepartureDate == DateTime.Parse(flightData[2])).ToList();
            if (flightData[3] != " ")
                foundFlights = foundFlights.Where(flight => flight.DepartureAirport == flightData[3]).ToList();
            if (flightData[4] != " ")
                foundFlights = foundFlights.Where(flight => flight.ArrivalAirport == flightData[4]).ToList();
            if (flightData[5] != " ")
                foundFlights = foundFlights.Where(flight => flight.Class[0] == flightData[5]).ToList();
            if (flightData[6] != " ")
                foundFlights = foundFlights.Where(flight => flight.FlightPrice[0] == int.Parse(flightData[6])).ToList();
            if (flightData[7] != " ")
                foundFlights = foundFlights.Where(flight => flight.Class[1] == flightData[7]).ToList();
            if (flightData[8] != " ")
                foundFlights = foundFlights.Where(flight => flight.FlightPrice[1] == int.Parse(flightData[8])).ToList();
            if (flightData[9] != " ")
                foundFlights = foundFlights.Where(flight => flight.Class[2] == flightData[9]).ToList();
            if (flightData[10] != " ")
                foundFlights = foundFlights.Where(flight => flight.FlightPrice[2] == int.Parse(flightData[10])).ToList();


            foreach (FlightData flight in foundFlights)
            {
                CSVfoundFlights.Add(FlightHandlerUtils.ConvertToCSV(flight));
            }
            return CSVfoundFlights;
        }
    }
}
