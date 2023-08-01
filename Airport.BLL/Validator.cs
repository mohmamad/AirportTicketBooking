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
            requiredFields.Add("Departure country");
            requiredFields.Add("Destination country");
            requiredFields.Add("Departure date");
            requiredFields.Add("Departure airport");
            requiredFields.Add("Arival airport");
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
            [Description("Valid flight")]
            Success = 6
        }
        public  bool ValidCountry(string country)
        {
            foreach (char letter in country)
            {
                if (letter > 'a' && letter < 'z' || letter > 'A' && letter < 'Z')
                {
                    return true;
                }
            }
            return false;
        }

        public  string ValidateFlight(string flightInfo)
        {
            //input format
            //depcountry,descountry,depDate,depAirport,ArriavalAirport,economy,price,bussenis,price,first class,price
            //if (flightInfo == null)
            //{
            //    return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.nullFlight.GetType().GetField(ErrorMessages.nullFlight.ToString())), typeof(DescriptionAttribute))).Description;
            //}
            string[] flightData = flightInfo.Split(',');
            if (flightData.Length < 7)
            {
                return ((DescriptionAttribute)Attribute.GetCustomAttribute((ErrorMessages.MissingData.GetType().GetField(ErrorMessages.MissingData.ToString())), typeof(DescriptionAttribute))).Description;
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
