using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DAL
{
    public interface IUserRepository
    {
        /// <summary>
        /// Returns a list of all the users data
        /// </summary>
        public string[] GetAllUsers();

        /// <summary>
        /// Stores a new user data
        /// </summary>
        public void Signup(User userInfo);
    }
}
