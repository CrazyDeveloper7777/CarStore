using CarShop.Services.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Common.Attributes
{
    public class UniqueUsername : ValidationAttribute
    { 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var usersService = (IUsersService)validationContext.GetService(typeof(IUsersService));
            if (usersService.CheckForUniqueUsernameAsync(value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The username is already taken.");
        }
    }
}
