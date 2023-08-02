using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.BLL
{
    public class Validator
    {
        List<string> requiredFields = new List<string>();
        public Validator() 
        {
            requiredFields.Add("Departure Country");
            requiredFields.Add("Destination Country");
            requiredFields.Add("Departure Date");
            requiredFields.Add("Departure Airport");
            requiredFields.Add("Arival Airport");
        }

        public enum ErrorMessages
        {
            [Description("null input on line: ")]
            NullFlight = 1,
            [Description("Missing Data on line: ")]
            MissingData = 2,
            [Description("A non valid country on line: ")]
            NotAValidCountry = 3,
            [Description("A non valid Date on line: ")]
            NotAValidDate = 4,
            [Description("A non valid Price on line: ")]
            NotAValidPrice = 5,
            [Description("Missing a required field: ")]
            MissingRequiredField = 6,
            [Description("Valid flight")]
            Success = 7
        }

        /// <summary>
        /// returns true if the given country is valid
        /// </summary>
        public bool ValidCountry(string country)
        {
            foreach (char c in country)
            {
                if (char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns the missing field of the flight information
        /// </summary>
        public string TheMissingField(int index)
        {
            switch (index)
            {
                case 0:
                    return "Departure Country";
                    break;
                case 1:
                    return "Destination Country";
                    break;
                case 2:
                    return "Departure Date";
                    break;
                case 3:
                    return "Departure Airport";
                    break;
                case 4:
                    return "Arival Airport";
                    break;
                case 5:
                    return "Flight Class(economy)";
                    break;
                case 6:
                    return "Flight Class Price(economy)";
                    break;
                case 7:
                    return "Flight Class(business)";
                    break;
                case 8:
                    return "Flight Class Price(business)";
                    break;
                case 9:
                    return "Flight Class(first class)";
                    break;
               default:
                    return "Flight Class Price(first class)";
                    break;
            }
        }

        /// <summary>
        /// Returns an error message specifying what is wrong in the flight information
        /// </summary>
        public string ValidateFlight(string flightInfo)
        {
           
            string[] flightData = flightInfo.Split(',');

            //checks that the format is correct
            if (flightData.Length < 11)
            {
                return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.MissingData.GetType().GetField(ErrorMessages.MissingData.ToString())), typeof(DescriptionAttribute))).Description;
            }

            //checks if all the required input exists
            for(int i = 0; i < flightData.Length; i++)
            {
                if (flightData[i] == " " && requiredFields.Contains(TheMissingField(i)))
                {
                    return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.MissingRequiredField.GetType().GetField(ErrorMessages.MissingRequiredField.ToString())), typeof(DescriptionAttribute))).Description
                        + $"{TheMissingField(i)} is missing on Line: ";
                }
            }
           

          

            ///country validation
            if (!ValidCountry(flightData[0]))
                return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.NotAValidCountry.GetType().GetField(ErrorMessages.NotAValidCountry.ToString())), typeof(DescriptionAttribute))).Description;
            if (!ValidCountry(flightData[1]))
                return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.NotAValidCountry.GetType().GetField(ErrorMessages.NotAValidCountry.ToString())), typeof(DescriptionAttribute))).Description;
            //date validation
            try
            {
                DateTime.Parse(flightData[2]);
            }
            catch (Exception e)
            {
                return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.NotAValidDate.GetType().GetField(ErrorMessages.NotAValidDate.ToString())), typeof(DescriptionAttribute))).Description;
            }

            //price validation
            for (int i = 6; i < flightData.Length; i += 2)
            {
                try
                {
                    int.Parse(flightData[i]);
                }
                catch (Exception e)
                {
                    return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.NotAValidPrice.GetType().GetField(ErrorMessages.NotAValidPrice.ToString())), typeof(DescriptionAttribute))).Description;
                }
            }

            return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.Success.GetType().GetField(ErrorMessages.Success.ToString())), typeof(DescriptionAttribute))).Description;
        }
    }
}
