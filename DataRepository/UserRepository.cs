
using System.Collections.Generic;

namespace Airport.DAL
{
    public class User { public string UserName; public string UserPassword; public string UserLevel; }
    public class UserRepository : IUserRepository
    {
        
        const string usersFilePath = @"C:\Users\GoldenTech\Desktop\study\intern\C#\exercise\Airprot\dataFiles\usersFile.txt";

        public string[] GetAllUsers() { return File.ReadAllLines(usersFilePath); }
      
        public void Signup(User userInfo) 
        { 
            File.AppendAllText(usersFilePath , UserRepositoryUtils.ConvertToCSV(userInfo)+ "\r\n"); 
        }
    }
}