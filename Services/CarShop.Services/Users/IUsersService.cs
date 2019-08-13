using CarShop.Data.Models;
using CarShop.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Users
{
    public interface IUsersService
    {
        Task PushDataOfConfirmationAsync(ConfirmAccountViewModel model, string userName);

        bool CheckForUniqueUsernameAsync(string userName);
    }
}
