using CarShop.Data.Models.Vehicles;
using CarShop.Data.Models.Vehicles.Contracts;
using CarShop.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Cars
{
    public interface ICarsService
    {
        Task CreateAsync(CreateCarViewModel model);

        Task EditAsync(EditCarViewModel carModel);

        Task DeleteAsync(Car car);

        Task<ICollection<Car>> GetAllCarsByUserIdAsync(string userId);

        Task<Car> GetCarByIdAsync(string carId);
    }
}
