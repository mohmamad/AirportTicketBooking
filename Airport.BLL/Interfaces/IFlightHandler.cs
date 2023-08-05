using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL.Interfaces
{
    public interface IFlightHandler
    {
        /// <summary>
        /// Returns a list of all the valid flights
        /// </summary>
        public List<string> ViewAllValidFlights();

        /// <summary>
        /// adds all the flights from the imported file path
        /// </summary>
        public List<string> AddFlight(string CSVFilePath);

        /// <summary>
        /// returns a list of flights that matches the given flight data
        /// </summary>
        public List<string> Search(string flightToSearch);
    }
}
