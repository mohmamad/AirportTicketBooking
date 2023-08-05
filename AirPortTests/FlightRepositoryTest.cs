using Airport.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortTests
{
    [TestClass]
    public class FlightRepositoryTest
    {
        [TestMethod]
        public void FlightAddTest()
        {
            //--arrange
            const string flightInfo = "palestine,japan,8/10/2023 12:00,potato,tomato,Economy,100,Business,120,First Class,150";
            FlightsRepository flightsRepository = new FlightsRepository();
            List<string> classes = new List<string>();
            List<int> prices = new List<int>();

            classes.Add("Economy");
            classes.Add("Business");
            classes.Add("First Class");

            prices.Add(100);
            prices.Add(120);
            prices.Add(150);
            Flight flight = new Flight
            {
                DepartureCountry = "palestine",
                DestinationCountry = "japan",
                DepartureDate = DateTime.Parse("8/10/2023 12:00"),
                DepartureAirport = "potato",
                ArrivalAirport = "tomato",
                Class = classes,
                FlightPrice = prices
            };
            flightsRepository.AddFlight(flight);
            string expected = "1,palestine,japan,8/10/2023 12:00:00 PM,potato,tomato,Economy,100,Business,120,First Class,150";

            //--act
            string[] actual = flightsRepository.GetAllFlights();

            //--assert
            Assert.AreEqual(expected, actual[0]);

        }
    }
}
