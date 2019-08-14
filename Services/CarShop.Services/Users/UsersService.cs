using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models;

namespace CarShop.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersService)
        {
            this.usersRepository = usersService;
        }

        public async Task<bool> CheckForUniqueEmail(string email)
        {

            if (this.usersRepository.AllWithDeleted().Any(u => u.Email == email && u.IsDeleted))
            {
                var user = this.usersRepository.AllWithDeleted().FirstOrDefault(u => u.Email == email);
                this.usersRepository.HardDelete(user);
                await this.usersRepository.SaveChangesAsync();

                return true;
            }
            else if (this.usersRepository.All().Any(u => u.Email == email))
            {
                return false;
            }

            return true;
        }

        public async Task<bool> CheckForUniqueUsernameAsync(string userName)
        {
            if (this.usersRepository.AllWithDeleted().Any(u => u.UserName == userName && u.IsDeleted))
            {
                var user = this.usersRepository.AllWithDeleted().FirstOrDefault(u => u.UserName == userName);
                this.usersRepository.HardDelete(user);
                await this.usersRepository.SaveChangesAsync();

                return true;
            }
            else if (this.usersRepository.All().Any(u => u.UserName == userName))
            {
                return false;
            }

            return true;
        }

        public async Task DeleteUserAsync(ApplicationUser user)
        {
            this.usersRepository.Delete(user);
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task PersistChangedPersonalData(ApplicationUser user, string firstName, string lastName, string country, string city)
        {
            if(firstName != null)
            {
                user.FirstName = firstName;
            }

            if (lastName != null)
            {
                user.LastName = lastName;
            }

            if (country != null)
            {
                user.Country = country;
            }

            if (city != null)
            {
                user.City = city;
            }

            this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();
        }
    }
}
