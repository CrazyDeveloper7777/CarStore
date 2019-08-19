using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Vehicles
{
    public interface IVehiclesService
    {
        Task<ICollection<Vehicle>> GetAllVehiclesByUserIdAsync(string userId);
    }
}
