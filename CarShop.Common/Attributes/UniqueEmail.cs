using CarShop.Services.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Common.Attributes
{
    public class UniqueEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var usersService = (IUsersService)validationContext.GetService(typeof(IUsersService));
            if (usersService.CheckForUniqueEmail(value.ToString()).GetAwaiter().GetResult())
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The email is already taken.");
        }
    }
}
