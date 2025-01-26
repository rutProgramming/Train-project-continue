using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Train_project.Core.Entities;

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

        public static bool IsValidGPSCoordinates(PointGPS locationGPSCoordinates)
        {
            double latitude = locationGPSCoordinates.X;
            double longitude = locationGPSCoordinates.Y;
            return latitude >= -90 && latitude <= 90 && longitude >= -180 && longitude <= 180;
        }
        public static bool LastTimeAfterFirstTime(DateTime Firstdate, DateTime LastDate)
        {
            return Firstdate <= LastDate;

        }
    }
}
