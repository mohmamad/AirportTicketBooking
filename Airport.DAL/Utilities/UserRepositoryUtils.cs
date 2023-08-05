using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.DAL.Repositories;

namespace Airport.DAL.Utilities
{
    public static class UserRepositoryUtils
    {
        /// <summary>
        /// convert User to CSV format
        /// </summary>
        public static string ConvertToCSV(User user)
        {
            StringBuilder userData = new StringBuilder();
            userData.Append(user.UserName + ",");
            userData.Append(user.UserPassword + ",");
            userData.Append(user.UserLevel);
            return userData.ToString();

        }
    }
}
