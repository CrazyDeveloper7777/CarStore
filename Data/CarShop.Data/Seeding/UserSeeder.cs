using CarShop.Common;
using CarShop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Seeding
{
    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager, GlobalConstants.TestAdministratorUsername);
            await SeedUserAsync(userManager, GlobalConstants.TestUserUsername);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                var password = userName + "@123";
                var result = await userManager.CreateAsync(new ApplicationUser(userName), password);

                if (result.Succeeded)
                {
                    user = await userManager.FindByNameAsync(userName);
                    if (userManager.Users.Count() == 1)
                    {
                        await userManager.AddToRoleAsync(user, "Administrator");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "User");
                    }
                }
                else
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
