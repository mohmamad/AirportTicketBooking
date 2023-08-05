using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.DAL.Repositories;

namespace Airport.DAL.Interfaces
{
    public interface IFlightRepository
    {
        /// <summary>
        /// Stores a new flight data
        /// </summary>
        public void AddFlight(Flight flightInfo);

        /// <summary>
        /// Returns a list of all the flights
        /// </summary>
        public string[] GetAllFlights();
    }
}
