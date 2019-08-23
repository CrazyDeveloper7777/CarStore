using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Motorcycles
{
    public interface IMotorcyclesService
    {
        Task<ICollection<Motorcycle>> GetAllMotorcyclesByUserId(string userId);
    }
}
