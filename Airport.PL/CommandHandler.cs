using Airport.BLL.Handlers;
using Airport.BLL.Interfaces;
using System.Text;

namespace Airport.PL
{
    public class CommandHandler
    {
        string userName = string.Empty;
        IUserHandler userHandler = new UserHandler();
        FlightHandler flightHandler = new FlightHandler();
        IBookingHandler bookingHandler = new BookingHandler();
        public List<string> ExcuteCommand(string command)
        {
            List<string> returnMessage = new List<string>();
            string[] commandData = command.Split(',');
            switch (commandData[0])
            {
                case "login":
                    returnMessage.Add(userHandler.Login(commandData[1], commandData[2]));
                    if (returnMessage[0] == "login successfully!")
                        userName = commandData[1];
                    return returnMessage;
                    break;
                case "signup":
                    returnMessage.Add(userHandler.Signup(commandData[1], commandData[2]));
                    if (returnMessage[0] == "signup was successful")
                        userName = commandData[1];
                    return returnMessage;
                    break;
            }
            if (userName != "manager")
                returnMessage = ExcutePassengerCommands(command);
            else
                returnMessage = ExcuteManagerCommands(command);
            return returnMessage;
        }
        /// <summary>
        /// excutes the passenger commands
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public List<string> ExcutePassengerCommands(string command)
        {
            List<string> returnMessage = new List<string>();
            string[] commandData = command.Split(',');
            switch (commandData[0])
            {
                case "view valid flights":
                    if (userName == string.Empty)
                    {
                        returnMessage.Add("Please Login or signup first.");
                        break;
                    }
                    returnMessage = flightHandler.ViewAllValidFlights();
                    if (returnMessage.Count == 0)
                        returnMessage.Add("There is no valid flights.");
                    break;
                case "search":
                    if (userName == string.Empty)
                    {
                        returnMessage.Add("Please Login or signup first.");
                        break;
                    }
                    returnMessage = flightHandler.Search(extractStringTosearchFromCommand(command));
                    if (returnMessage.Count == 0)
                        returnMessage.Add("There is no flight with the given data.");
                    break;
                case "delete booking":
                    if (userName == string.Empty)
                    {
                        returnMessage.Add("Please Login or signup first.");
                        break;
                    }
                    bookingHandler.DeleteBooking(int.Parse(commandData[1]));
                    returnMessage.Add("Booking deleted successfully!");
                    break;
                case "view all bookings":
                    if (userName == string.Empty)
                    {
                        returnMessage.Add("Please Login or signup first.");
                        break;
                    }
                    returnMessage = bookingHandler.ViewAllUserBookings(userName);
                    if (returnMessage.Count == 0)
                        returnMessage.Add("There is no bookings.");
                    break;
                case "update booking class":
                    if (userName == string.Empty)
                    {
                        returnMessage.Add("Please Login or signup first.");
                        break;
                    }
                    returnMessage.Add(bookingHandler.Update(int.Parse(commandData[1]), commandData[2]));
                    break;
                case "book":
                    if (userName == string.Empty)
                    {
                        returnMessage.Add("Please Login or signup first.");
                        break;
                    }
                    bookingHandler.Book(extractStringTosearchFromCommand(command), userName);
                    returnMessage.Add("Flight booked successfully!");
                    break;
            }
            return returnMessage;
        }

        /// <summary>
        /// excutes the manager commands
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public List<string> ExcuteManagerCommands(string command)
        {
            List<string> returnMessage = new List<string>();
            string[] commandData = command.Split(',');
            switch (commandData[0])
            {
                case "view valid flights":
                    returnMessage = flightHandler.ViewAllValidFlights();
                    if (returnMessage.Count == 0)
                        returnMessage.Add("There is no valid flights.");
                    break;
                case "booking search":
                    returnMessage = bookingHandler.Search(extractStringTosearchFromCommand(command));
                    if (returnMessage.Count == 0)
                        returnMessage.Add("There is no booking with the given data.");
                    break;
                case "add flights":
                    returnMessage = flightHandler.AddFlight(commandData[1]);
                    break;
                case "view model validation":
                    returnMessage = flightHandler.GetValidationModle();
                    break;

            }
            return returnMessage;
        }

        /// <summary>
        /// extracts the info from the command name
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        public string extractStringTosearchFromCommand(string infos)
        {
            StringBuilder newString = new StringBuilder();
            for(int i = 1;i < infos.Split(',').Length; i++)
            {
                newString.Append(infos.Split(',')[i] + ",");
            }
            return newString.ToString();    
        }
    }
}
