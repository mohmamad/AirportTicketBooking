using Airport.DAL;
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
            const string flightInfo = "100,palestine,japan,August 10 2023 12:00,potato,tomato,Economy,Business,First Class";
            FlightsRepository flightsRepository = new FlightsRepository();
            flightsRepository.AddFlight(flightInfo);
            string expected = "1,100,palestine,japan,8/10/2023 12:00:00 PM,potato,tomato,Economy,Business,First Class";

            //--act
            List<FlightData> actual = flightsRepository.GetAllFlights();

            //--assert
            foreach(FlightData act in actual)
            {
                Assert.AreEqual(act.FlightId , expected.Split(',')[0]);
                Assert.AreEqual(act.FlightPrice, int.Parse(expected.Split(',')[1]));
                Assert.AreEqual(act.DepartureCountry, expected.Split(',')[2]);
                Assert.AreEqual(act.DestinationCountry, expected.Split(',')[3]);
                Assert.AreEqual(act.DepartureDate, DateTime.Parse(expected.Split(',')[4]));
                Assert.AreEqual(act.DepartureAirport, expected.Split(',')[5]);
                Assert.AreEqual(act.ArrivalAirport, expected.Split(',')[6]);
                Assert.AreEqual(act.Class[0], expected.Split(',')[7]);
                Assert.AreEqual(act.Class[1], expected.Split(',')[8]);
                Assert.AreEqual(act.Class[2], expected.Split(',')[9]);
            }
            
        }
    }
}
