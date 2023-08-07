
namespace Airport.PL
{
    public class CommandValidator
    {
        public bool ValidateCommand(string command)
        {
            HashSet<string> allCommands = new HashSet<string>(); 
            allCommands.Add("login"); allCommands.Add("signup");
            switch (command.Split(',')[0])
            {
                case "login":
                    if(command.Split(',').Length < 3)
                        return false;
                    break;
                case "signup":
                    if (command.Split(',').Length < 3)
                        return false;
                    break;
                case "view valid flights":
                    return true;
                    break;
                case "search":
                    if (command.Split(',').Length < 8)
                        return false;
                    return true;
                    break;
                case "delete booking":
                    if (command.Split(',').Length < 2)
                        return false;
                    return true;
                    break;
                case "view all bookings":
                    return true;
                    break;
                case "update booking class":
                    if (command.Split(',').Length < 3)
                        return false;
                    return true;
                    break;
                case "book":
                    if (command.Split(',').Length < 9)
                        return false;
                    return true;
                    break;
                case "booking search":
                    if (command.Split(',').Length < 10)
                        return false;
                    return true;
                    break;
                case "add flights":
                    if (command.Split(',').Length < 2)
                        return false;
                    return true;
                    break;
                case "view model validation":
                    return true;
                    break;
                default: return false;
            }
            return true;
        }
    }
}
