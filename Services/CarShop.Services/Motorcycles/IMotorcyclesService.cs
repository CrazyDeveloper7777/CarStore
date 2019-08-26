using CarShop.Data.Models.Vehicles;
using CarShop.Web.ViewModels.Motorcycles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Motorcycles
{
    public interface IMotorcyclesService
    {
        Task<ICollection<Motorcycle>> GetAllMotorcyclesByUserId(string userId);

        Task<Motorcycle> GetMotorcycleByIdAsync(string motorcycleId);

        Task CreateAsync(CreateMotorcycleViewModel inputModel);

        Task EditAsync(EditMotorcycleViewModel busModel);

        Task DeleteAsync(Motorcycle motorcycle);
    }
}
