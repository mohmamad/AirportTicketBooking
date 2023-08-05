using Airport.BLL.Handlers;
using Airport.BLL.Interfaces;

namespace Airport.BLLTests
{
    [TestClass]
    public class FlightHandlerTest
    {
        [TestMethod]
        public void AddFlightsTest()
        {
            //--arrange
            IFlightHandler flightHandler = new FlightHandler();
            string expected1 = "The country name most not have any numbers or special characters , The field DepartureDate is invalid. , the flight most have an arrival airport ,  On Line: 1";
            string expected2 = "the flight most have a price , the flight most have a class ,  On Line: 2";
            string expected3 = "Flights added successfully!";
            //--act
            List<string> actual = flightHandler.AddFlight("C:\\Users\\GoldenTech\\Desktop\\test.txt");
            List<string> actual1 = flightHandler.AddFlight("C:\\Users\\GoldenTech\\Desktop\\test2.txt");
            //--assert

            Assert.AreEqual(expected1, actual[0]);
            Assert.AreEqual(expected2, actual[1]);
            Assert.AreEqual(expected3, actual1[0]);

        }

        [TestMethod]
        public void ViewAllTest()
        {
            //--arrange 
            FlightHandler flightHandler = new FlightHandler();
            string expected1 = "1,palestine,japan,8/10/2023 12:00:00 PM,potato,tomato,Economy,100,Business,120";
            string expected2 = "2,palestine,japan,8/10/2023 12:00:00 PM,potato,tomato,Economy,100,Business,120,First Class,150";
            string expected3 = "3,palestine,japan,8/10/2023 12:00:00 PM,potato,tomato,Economy,100,Business,120,First Class,150";
            //--act
            List<string> act = flightHandler.ViewAllValidFlights();
            //--assert
            Assert.AreEqual(expected1, act[0]);
            Assert.AreEqual(expected2, act[1]);
            Assert.AreEqual(expected3, act[2]);

        }

        [TestMethod]
        public void SearchTest()
        {
            //--arrange 
            FlightHandler flightHandler = new FlightHandler();
            List<string> expected = new List<string>();
            expected.Add("2,palestine,japan,8/10/2023 12:00:00 PM,potato,tomato,Economy,100,Business,120,First Class,150");
            expected.Add("3,palestine,japan,8/10/2023 12:00:00 PM,potato,tomato,Economy,100,Business,120,First Class,150");
            //--act
            List<string> act = flightHandler.Search("palestine, ,8/10/2023 12:00:00 PM, ,tomato,Economy,100,Business,120,First Class,150");
            //--assert
            for(int i = 0; i < act.Count; i++)
            {
                Assert.AreEqual(expected[i], act[i]);

            }


        }

    }
}