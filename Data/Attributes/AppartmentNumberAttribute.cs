﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CustomersTable.Data.Attributes
{
    public class AppartmentNumberAttribute : ValidationAttribute
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

            // Regex pattern to match alphanumeric characters, hyphens, and slashes
            var appartmentNumberPattern = @"^[0-9]{1,4}[a-zA-Z]?$";
            if (string.IsNullOrEmpty(stringValue) || Regex.IsMatch(stringValue, appartmentNumberPattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Only alphanumeric characters, hyphens, and slashes are allowed.");
        }
    }
}
