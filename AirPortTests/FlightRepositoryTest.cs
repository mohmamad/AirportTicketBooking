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
            const string flightInfo = "palestine,japan,8/10/2023 12:00,potato,tomato,Economy,100,Business,120,First Class,150";
            FlightsRepository flightsRepository = new FlightsRepository();
            flightsRepository.AddFlight(flightInfo);
            string expected = "1,palestine,japan,August 10 2023 12:00,potato,tomato,Economy,100,Business,120,First Class,150";

            //--act
            List<FlightData> actual = flightsRepository.GetAllFlights();

            //--assert
            foreach(FlightData act in actual)
            {
                Assert.AreEqual(act.FlightId , expected.Split(',')[0]);
                Assert.AreEqual(act.DepartureCountry, expected.Split(',')[1]);
                Assert.AreEqual(act.DestinationCountry, expected.Split(',')[2]);
                Assert.AreEqual(act.DepartureDate, DateTime.Parse(expected.Split(',')[3]));
                Assert.AreEqual(act.DepartureAirport, expected.Split(',')[4]);
                Assert.AreEqual(act.ArrivalAirport, expected.Split(',')[5]);
                Assert.AreEqual(act.Class[0], expected.Split(',')[6]);
                Assert.AreEqual(act.FlightPrice[0], int.Parse(expected.Split(',')[7]));
                Assert.AreEqual(act.Class[1], expected.Split(',')[8]);
                Assert.AreEqual(act.FlightPrice[1], int.Parse(expected.Split(',')[9]));
                Assert.AreEqual(act.Class[2], expected.Split(',')[10]);
                Assert.AreEqual(act.FlightPrice[2], int.Parse(expected.Split(',')[11]));
            }
            
        }
    }
}
