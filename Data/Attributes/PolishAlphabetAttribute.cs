using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CustomersTable.Data.Attributes
{
    public class PolishAlphabetAttribute : ValidationAttribute
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

            // Regex pattern to match Polish characters
            var polishPattern = @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\ s]+$";
            if (Regex.IsMatch(stringValue, polishPattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Only Polish characters are allowed.");
        }
    }
}
