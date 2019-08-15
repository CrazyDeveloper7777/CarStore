using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Common.Attributes
{
    public class BGPhoneNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }

            if (!value.ToString().StartsWith("0"))
            {
                return new ValidationResult("The phone number must starts with 0.");
            }

            if (value.ToString().Length != 10)
            {
                return new ValidationResult("The phone number must be exact 10 digits.");
            }

            return ValidationResult.Success;
        }
    }
}
