using Airport.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.Utilities
{
    public static class UserHandlerUtils
    {
        public static string ConvertToCSV(User user)
        {
            StringBuilder userCSV = new StringBuilder();
            userCSV.Append(user.UserName + ",");
            userCSV.Append(user.UserPassword + ",");
            userCSV.Append(user.UserLevel);
            return userCSV.ToString();
        }

        public static User ConvertToUser(string user)
        {
            return new User { UserName = user.Split(',')[0], UserPassword = user.Split(',')[1], UserLevel = user.Split(',')[2] };
        }
    }
}
