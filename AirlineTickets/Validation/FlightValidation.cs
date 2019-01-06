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
    public class FlightValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z0-9]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Flight Number Format is Wrong");
        }
    }

    public class OneWayTicketPriceValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[0-9]*(?:\.[0-9]*)?$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Ticket Price Format is Wrong");
        }
    }
}
