using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models;
using CarShop.Web.ViewModels.Users;

namespace CarShop.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersService;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersService)
        {
            this.usersService = usersService;
        }

        public bool CheckForUniqueUsernameAsync(string userName)
        {
            if (this.usersService.All().Any(u => u.UserName == userName))
            {
                return false;
            }

            return true;
        }

        public async Task PushDataOfConfirmationAsync(ConfirmAccountViewModel model, string userName)
        {
            var user = this.usersService.All().FirstOrDefault(u => u.UserName == userName);

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            this.usersService.Update(user);
            await this.usersService.SaveChangesAsync();
        }
    }
}
