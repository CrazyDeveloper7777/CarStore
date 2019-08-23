using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Buses
{
    public interface IBusesService
    {
        Task<ICollection<Bus>> GetAllBusesByUserId(string userId);
    }
}
