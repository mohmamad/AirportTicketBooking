using Airport.BLL;

namespace Airport.BLLTests
{
    [TestClass]
    public class FlightHandlerTest
    {
        [TestMethod]
        public void AddFlightsTest()
        {
            //--arrange
            FlightHandler flightHandler = new FlightHandler();
            string expected = "A non valid Date on line: 3";
            
            //--act
            List<string> actual = flightHandler.AddFlight("C:\\Users\\GoldenTech\\Desktop\\test.txt");
            //--assert
            foreach (string act in actual) 
            {
                Assert.AreEqual(expected, act);
            }
        }

        [TestMethod]
        public void ViewAllTest()
        {
            //--arrange 
            FlightHandler flightHandler = new FlightHandler();
            string expected = "1,\r\npalestine,\r\nasdasd,\r\n9/10/2023 12:00:00 PM,\r\npotato,\r\ntomato,\r\nEconomy,\r\n100,\r\nBusiness,\r\n120,\r\nEconomy,\r\n100,\r\nBusiness,\r\n120,";
           //--act
            List<string> act = flightHandler.ViewAllValidFlights();
            //--assert
           // Assert.AreEqual(expected, act[0]);
            Assert.AreEqual(expected, act[1]);

        }

        [TestMethod]
        public void SearchTest()
        {
            //--arrange 
            FlightHandler flightHandler = new FlightHandler();
            string expected = "palestine,asdasd,8/10/2023 12:00,potato,tomato,Economy,100,Business,120";
            //--act
            List<string> act = flightHandler.Search("palestine,asdasd,8/10/2023 12:00,potato,tomato,Economy,100,Business,120, , ");
            //--assert
             Assert.AreEqual(expected, act[0]);
            

        }

    }
}