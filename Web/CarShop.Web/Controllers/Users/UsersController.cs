using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Services.Users;
using CarShop.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.Users
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult ConfirmAccount()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAccount(ConfirmAccountViewModel model, string username)
        {
            if (this.ModelState.IsValid)
            {
                await this.usersService.PushDataOfConfirmationAsync(model, username);
            }

            return this.Redirect("/Identity/Account/Login");
        }
    }
}