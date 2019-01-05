using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AirlineTickets.Validation
{
    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            if (value != null)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "Username is required");
        }
    }

    //class SurnameValidation : ValidationRule
    //{
    //    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    //    {
    //        if (value.ToString().Equals(String.Empty))
    //        {
    //            return new ValidationResult(false, "Surname can't be empty");
    //        }
    //        return new ValidationResult(true, "Correct format");
    //    }

    //}
}
