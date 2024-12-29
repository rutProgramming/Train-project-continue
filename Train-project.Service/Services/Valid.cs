using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Train_project.Service.Services
{
    internal class Valid
    {
        public static bool IsIdValid(string id)
        {
            id = id.Trim();
            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                return false;
            }

            int sum = 0;

            for (int i = 0; i < id.Length; i++)
            {
                int digit = id[i] - '0'; 
                digit *= (i % 2) + 1;    

                if (digit > 9)
                {
                    digit = (digit / 10) + (digit % 10);
                }

                sum += digit;
            }

            return sum % 10 == 0;

        }
        public static bool IsIsraeliPhoneNumberValid(string phoneNumber)
        {
            string pattern = @"^0?(([23489]{1}\d{7})|[5]{1}[012345689]\d{7})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidGPSCoordinates(string locationGPSCoordinates)
        {
            string pattern = @"^-?([1-8]?[0-9](\.\d+)?|90(\.0+)?),\s*-?(1[0-7][0-9](\.\d+)?|[0-9]?[0-9](\.\d+)?|180(\.0+)?)$";
            return Regex.IsMatch(locationGPSCoordinates, pattern);
        }
        public static bool LastTimeAfterFirstTime(DateTime Firstdate, DateTime LastDate)
        {
            return Firstdate <= LastDate;

        }
    }
}
