using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CustomersTable.Data.Attributes
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var stringValue = value as string;
            if (stringValue == null)
            {
                return new ValidationResult("This attribute can only be applied to string properties.");
            }

            // Regex pattern to match exactly 9 digits
            var phoneNumberPattern = @"^\d{9}$";
            if (Regex.IsMatch(stringValue, phoneNumberPattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The phone number must be exactly 9 digits.");
        }
    }
}
