﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CustomersTable.Data.Attributes
{
    public class HouseNumberAttribute : ValidationAttribute
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

            // Regex pattern to match up to 3 digits followed by exactly 1 English letter
            var houseNumberPattern = @"^[0-9]{1,3}[a-zA-Z]?$";
            if (Regex.IsMatch(stringValue, houseNumberPattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid house number");
        }
    }
}
