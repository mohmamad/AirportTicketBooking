
namespace Airport.PL
{
    internal class Application
    {
        private static void Main(string[] args)
        {
            CommandValidator validate = new CommandValidator();
            CommandHandler commandHandler = new CommandHandler();
            List<string> messages = new List<string>();
            string[] userCommands = File.ReadAllLines("C:\\Users\\GoldenTech\\Desktop\\study\\intern\\C#\\exercise\\Airprot\\UserCommands.txt");
            string[] managerCommands = File.ReadAllLines("C:\\Users\\GoldenTech\\Desktop\\study\\intern\\C#\\exercise\\Airprot\\ManagerCommands.txt");
            
            Console.WriteLine(@"Please login or sign up:
signup <user name>,<password>
login <user name>,<password>");
            
            string command = "";
            while (command != "exit")
            {
                command = Console.ReadLine();
                if (validate.ValidateCommand(command))
                    messages = commandHandler.ExcuteCommand(command);
                else
                    messages.Add("Unvalid command!");
                foreach (string message in messages)
                {
                    Console.WriteLine(message);
                }
                if(command.Split(',').Length >= 2)
                {
                    if ((command.Split(',')[0] == "login" || command.Split(',')[0] == "signup") && command.Split(',')[1] != "manager" && messages[0] == "login successfully!" || messages[0] == "signup was successful")
                    {
                        Console.WriteLine("Here are the passenger commands:");
                        foreach (string userCommand in userCommands)
                        {
                            Console.WriteLine(userCommand);
                        }
                    }
                }

                if (command.Split(',').Length > 1)
                {
                    if ((command.Split(',')[0] == "login") && command.Split(',')[1] == "manager" && messages[0] == "login successfully!")
                    {
                        Console.WriteLine("Here are the manager commands:");
                        foreach (string managerCommand in managerCommands)
                        {
                            Console.WriteLine(managerCommand);
                        }
                    }
                }
            }
        }
    }
}