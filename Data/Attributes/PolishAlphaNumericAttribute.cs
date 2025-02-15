﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CustomersTable.Data.Attributes
{
    public class PolishAlphanumericAttribute : ValidationAttribute
    {
        private static readonly Regex PolishAlphanumericRegex = new Regex(
            @"^[a-zA-Z0-9ąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s.]{1,50}$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var stringValue = value as string;
            if (stringValue != null && stringValue.Length > 50)
            {
                return new ValidationResult("The input is too long");
            }
            if (stringValue != null && PolishAlphanumericRegex.IsMatch(stringValue))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Only Polish alphanumeric characters are allowed.");
        }
    }
}
