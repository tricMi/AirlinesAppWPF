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
    public class InputValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[0-9]*(?:\.[0-9]*)?$")  && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Input Format is Wrong");
        }
    }

    public class PilotValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Pilot Name Format is Wrong!");
        }
    }

    public class RowNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[0-9]*(?:\.[0-9]*)?$")  && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Row Format is Wrong");
        }
    }

    public class ColumnNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[0-9]*(?:\.[0-9]*)?$")  && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Column Format is Wrong");
        }
    }
}
