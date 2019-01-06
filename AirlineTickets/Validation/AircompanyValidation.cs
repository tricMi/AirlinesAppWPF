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
    public class AircompanyValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Any(char.IsUpper) && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Company Name Format is Wrong");
        }
    }

    public class CompanyPasswordValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Company Password Format is Wrong");
        }
    }
}
