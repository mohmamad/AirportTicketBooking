using Airport.BLL.Interfaces;
using Airport.BLL.Utilities;
using Airport.DAL.Interfaces;
using Airport.DAL.Repositories;

namespace Airport.BLL.Handlers
{
    public class UserHandler : IUserHandler
    {
        IUserRepository users = new UserRepository();
        public string Login(string userName, string password)
        {
            if (userName == "manager")
            {
                const string success = "login successfully!";
                const string failed = "Failed to login: Wrong user name or password.";
                string[] user = users.GetAllUsers();
                User userData = new User { UserName = userName, UserPassword = password, UserLevel = "1" };
                if (user.ToList().Contains(UserHandlerUtils.ConvertToCSV(userData)))
                {
                    return success;
                }
                return failed;
            }
            else
            {
                const string success = "login successfully!";
                const string failed = "Failed to login: Wrong user name or password.";
                UserRepository users = new UserRepository();
                string[] user = users.GetAllUsers();
                User userData = new User { UserName = userName, UserPassword = password, UserLevel = "0" };
                if (user.ToList().Contains(UserHandlerUtils.ConvertToCSV(userData)))
                {
                    return success;
                }
                return failed;
            }

        }

        public string Signup(string userName, string password)
        {
            if (userName == "manager")
            {
                if (Login(userName, password) != "login successfully!")
                {
                    users.Signup(UserHandlerUtils.ConvertToUser($"{userName},{password},1"));
                    return "signup was successful";
                }
                return "signup failed user already exists";
            }
            else
            {
                if (Login(userName, password) != "login successfully!")
                {
                    users.Signup(UserHandlerUtils.ConvertToUser($"{userName},{password},0"));
                    return "signup was successful";
                }
                return "signup failed user already exists";
            }
            
           
        }
    }
}