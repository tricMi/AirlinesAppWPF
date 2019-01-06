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
    public class NameValidation : ValidationRule
    {
        

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Name Format is Wrong!");
        }
    }

    public class SurnameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Surname Format is Wrong");
        }

    }

    public class UsernameValidation : ValidationRule
    {
        

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z0-9]+$") || Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Username Format is Wrong");
        }

    }

    public class AddressValidation : ValidationRule
    {


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z0-9]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Address Format is Wrong");
        }

    }

    public class EmailValidation : ValidationRule
    {
        Regex regex = new Regex(@"^[a-zA-Z]+$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Any(char.IsLetter) && value.ToString().Contains("@") && value.ToString().EndsWith(".com") && value != null)
            {
                return new ValidationResult(true, "Email Format is Correct!");
            }
            return new ValidationResult(false, "Email Format is Wrong!");
        }
    }

    public class PasswordValidation : ValidationRule
    {
        

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^[a-zA-Z0-9]+$") && value != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Password Format is Wrong!");
        }
    }
}
