using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.Interfaces
{
    public interface IUserHandler
    {

        /// <summary>
        /// checks if the intered user name and password exists
        /// </summary>
        public string Login(string userName, string password);

        /// <summary>
        /// adds a new user
        /// </summary>
        public string Signup(string userName, string password);
    }
}
