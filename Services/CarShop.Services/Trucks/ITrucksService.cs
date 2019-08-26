using CarShop.Data.Models.Vehicles;
using CarShop.Web.ViewModels.Trucks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Trucks
{
    public interface ITrucksService
    {
        Task<ICollection<Truck>> GetAllTrucksByUserIdAsync(string userId);

        Task<Truck> GetTruckByIdAsync(string truckId);

        Task CreateAsync(CreateTruckViewModel inputModel);

        Task EditAsync(EditTruckViewModel truckModel);

        Task DeleteAsync(Truck truck);
    }
}
