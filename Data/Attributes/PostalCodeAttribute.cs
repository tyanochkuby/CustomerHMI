using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CustomersTable.Data.Attributes
{
    public class PostalCodeAttribute : ValidationAttribute
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

            var postalCodePattern = @"^\d{2}-\d{3}$";
            if (Regex.IsMatch(stringValue, postalCodePattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The field contains invalid characters. The postal code must be in the format XX-XXX.");
        }
    }
}
