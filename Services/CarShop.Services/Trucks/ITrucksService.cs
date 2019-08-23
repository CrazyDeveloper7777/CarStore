using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Trucks
{
    public interface ITrucksService
    {
        Task<ICollection<Truck>> GetAllTrucksByUserId(string userId);
    }
}
