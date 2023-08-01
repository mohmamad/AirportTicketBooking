using Airport.DAL;
namespace Airport.BLL
{
    public class UserHandler
    {
        UserRepository users = new UserRepository();
        public string Login(string userName , string password)
        {
            if(userName == "manager") 
            {
                const string success = "login successfully!";
                const string failed = "Failed to login: Wrong user name or password.";
                List<UserData> user = users.GetAllUsers();
                UserData userData = new(userName, password, "1");
                if (user.Contains(userData))
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
                List<UserData> user = users.GetAllUsers();
                UserData userData = new(userName, password, "0");
                if (user.Contains(userData))
                {
                    return success;
                }
                return failed;
            }
            
        }

        public bool Signup(string userName , string password)
        {
            if(Login(userName, password) != "login successfully!") { users.Signup($"{userName},{password},0"); return true; }
            return false;
        }
    }
}