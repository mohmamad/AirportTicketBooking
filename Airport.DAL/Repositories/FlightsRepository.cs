using System.ComponentModel.DataAnnotations;
using Airport.DAL.attributes;
using Airport.DAL.Interfaces;
using Airport.DAL.Utilities;

namespace Airport.DAL.Repositories
{
    public class Flight
    {
        [Required(ErrorMessage = "the flight ID can not be empty")]
        public int FlightId { set; get; }

        [Required(ErrorMessage = "the flight most have a price")]
        public List<int> FlightPrice { set; get; }
        [Required(ErrorMessage = "the flight most have a departure country")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "The country name most not have any numbers or special characters")]
        public string DepartureCountry { set; get; }
        [Required(ErrorMessage = "the flight most have a destination country")]
        [RegularExpression("^[A-Za-z ]+$")]
        public string DestinationCountry { set; get; }
        [ValidDate]
        public DateTime DepartureDate { set; get; }
        [Required(ErrorMessage = "the flight most have a departure airport")]
        public string DepartureAirport { set; get; }
        [Required(ErrorMessage = "the flight most have an arrival airport")]
        public string ArrivalAirport { set; get; }
        [Required(ErrorMessage = "the flight most have a class")]
        public List<string> Class { set; get; }
    }
    public class FlightsRepository : IFlightRepository
    {
        const string flightsFilePath = @"C:\Users\GoldenTech\Desktop\study\intern\C#\exercise\Airprot\dataFiles\flightsFile.txt";

        public string[] GetAllFlights()
        {
            string[] allFlights = File.ReadAllLines(flightsFilePath);
            return allFlights;
        }

        public void AddFlight(Flight flightInfo)
        {
            int flightId = 1;

            //to generate the flight ID
            if (GetAllFlights().Length > 0)
            {
                int index = GetAllFlights().Length - 1;
                flightId += int.Parse(GetAllFlights()[index].Split(',')[0]);
            }

            flightInfo.FlightId = flightId;
            File.AppendAllText(flightsFilePath, FlightRepositoryUtils.ConvertToCSV(flightInfo) + "\r\n");
        }

    }
}
