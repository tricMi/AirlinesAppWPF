using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AirlineTickets.Validation
{
    public class AirportIdValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z0-9]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "AirportID Format is Wrong!");
        }

        
    }

    public class AirportNameValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Airport Name Format is Wrong!");
        }


    }

    public class CityValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "City Format is Wrong!");
        }


    }
}
