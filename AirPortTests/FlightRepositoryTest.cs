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
            const string flightInfo = "100,palestine,japan,August 10 2023 12:00,potato,tomato,economy";
            FlightsRepository flightsRepository = new FlightsRepository();
            flightsRepository.AddFlight(flightInfo);
            string expected = "1,100,palestine,japan,August 10 2023 12:00,potato,tomato,economy";
            //--act
            List<FlightData> actual = flightsRepository.GetAll();

            //--assert
            foreach(FlightData act in actual)
            {
                Assert.AreEqual(act , expected);
            }
            
        }
    }
}
