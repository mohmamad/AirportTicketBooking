using Airport.BLL.FlightFilter;
using Airport.BLL.Interfaces;
using Airport.BLL.Utilities;
using Airport.BLL.ValidationModels;
using Airport.DAL.Interfaces;
using Airport.DAL.Repositories;

namespace Airport.BLL.Handlers
{
    public class FlightHandler : IFlightHandler
    {
        IFlightRepository flights = new FlightsRepository();
        ValidationModel validate = new ValidationModel();
        FlightComposite filterBy = new FlightComposite();

        public List<string> ViewAllValidFlights()
        {
            string[] validFlights = flights.GetAllFlights();
            List<Flight> flightsList = new List<Flight>();
            foreach (string flight in validFlights)
            {
                flightsList.Add(FlightHandlerUtils.ConvertToFlight(flight));
            }
            flightsList = flightsList.Where(flight => flight.DepartureDate > DateTime.Now).Select(flight => flight).ToList();
            List<string> flightsCSVFormat = new List<string>();
            foreach (Flight flightData in flightsList)
            {
                flightsCSVFormat.Add(FlightHandlerUtils.ConvertToCSV(flightData));
            }
            return flightsCSVFormat;
        }


        public List<string> AddFlight(string CSVFilePath)
        {
            bool isValid = true;
            List<string> errorMessages = new List<string>();
            string message = string.Empty;

            if (!File.Exists(CSVFilePath)) { errorMessages.Add("File Not Found!"); return errorMessages; }

            string[] newFlights = File.ReadAllLines(CSVFilePath);
            foreach (string flight in newFlights)
            {
                message = validate.ValidateFlight(flight);

                if (message != "Valid flight")
                { isValid = false; errorMessages.Add($"{message} On Line: {newFlights.ToList().IndexOf(flight) + 1}"); }

            }
            if (!isValid) return errorMessages;

            errorMessages.Add("Flights added successfully!");
            foreach (string flight in newFlights)
            {
                flights.AddFlight(FlightHandlerUtils.ConvertToFlight(flight));
            }
            return errorMessages;
        }


        public List<string> Search(string flightToSearch)
        {
            List<string> CSVfoundFlights = new List<string>();
            string[] flightData = flightToSearch.Split(',');

            Flight searchFlight = FlightHandlerUtils.ConvertToFlight(flightToSearch);

            List<Flight> foundFlights = new List<Flight>();
            string[] flightsCsv = flights.GetAllFlights();
            foreach (string flight in flightsCsv)
            {
                foundFlights.Add(FlightHandlerUtils.ConvertToFlight(flight));
            }
            if (flightData[0] != " ")
                filterBy.add(new FlightDepartureCountry(searchFlight.DepartureCountry));
            if (flightData[1] != " ")
                filterBy.add(new FlightDestinationCountry(searchFlight.DestinationCountry));
            if (flightData[2] != " ")
                filterBy.add(new FlightDepartureDate(searchFlight.DepartureDate));
            if (flightData[3] != " ")
                filterBy.add(new FlightDepartureAirport(searchFlight.DepartureAirport));
            if (flightData[4] != " ")
                filterBy.add(new FlightArrivalAirport(searchFlight.ArrivalAirport));
            if (searchFlight.Class.Count != 0)
                filterBy.add(new FlightClass(searchFlight.Class));
            if (searchFlight.FlightPrice.Count != 0)
                filterBy.add(new FlightPrice(searchFlight.FlightPrice));

            foundFlights = filterBy.Filter(foundFlights);

            foreach (Flight flight in foundFlights)
            {
                CSVfoundFlights.Add(FlightHandlerUtils.ConvertToCSV(flight));
            }
            return CSVfoundFlights;
        }

        /// <summary>
        /// Returns a list of all the validation models of the flight fields
        /// </summary>
        public List<string> GetValidationModle()
        {
            List<string> fieldsConstraints = new List<string>();
            fieldsConstraints.Add("Departure Country\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("Destination Country\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add($"Departure Date\r\nDate Time\r\nRequired\r\nAllowed Range: {DateTime.Now} => future");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("Departure Airport\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("Arrival Country\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("Economy Class\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("Economy Class price\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("Business Class\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("Business Class price\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("First Class\r\nFree Text\r\nRequired");
            fieldsConstraints.Add("________________________________________________________");
            fieldsConstraints.Add("First Class price\r\nFree Text\r\nRequired");


            return fieldsConstraints;
        }


    }
}
