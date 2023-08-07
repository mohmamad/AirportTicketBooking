using Airport.DAL.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Airport.BLL.ValidationModels
{
    public class ValidationModel
    {

        /// <summary>
        /// Returns an error message specifying what is wrong in the flight information
        /// </summary>
        public string ValidateFlight(string flightInfo)
        {
            // List<string> errors = new List<string>();
            StringBuilder error = new StringBuilder();
            string[] flightData = flightInfo.Split(',');

            List<string> classes = new List<string>();
            List<int> prices = new List<int>();

            for (int i = 5; i < flightData.Length; i += 2)
            {
                classes.Add(flightData[i]);
                prices.Add(int.Parse(flightData[i + 1]));
            }
            if (flightData.Length < 6) { classes = null; prices = null; }
            var flight = new Flight
            {
                DepartureCountry = flightData[0],
                DestinationCountry = flightData[1],
                DepartureDate = DateTime.Parse(flightData[2]),
                DepartureAirport = flightData[3],
                ArrivalAirport = flightData[4],
                Class = classes,
                FlightPrice = prices
            };

            var validationContext = new ValidationContext(flight);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(flight, validationContext, validationResults, true);


            // Check if the object is valid or not
            if (isValid)
            {
                error.Append("Valid flight");
            }
            else
            {
                // Print validation errors
                foreach (var validationResult in validationResults)
                {
                    error.Append($"{validationResult.ErrorMessage} , ");
                }
            }

            return error.ToString();

        }
    }
}
