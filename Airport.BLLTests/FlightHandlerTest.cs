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
            string expected = "Flights added successfully!";
            
            //--act
            List<string> actual = flightHandler.AddFlight("C:\\Users\\GoldenTech\\Desktop\\test.txt");
            //--assert
            foreach (string act in actual) 
            {
                Assert.AreEqual(expected, act);
            }
        }
     
    }
}