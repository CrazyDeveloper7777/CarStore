using CarShop.Data.Models.Vehicles;
using CarShop.Web.ViewModels.Buses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Buses
{
    public interface IBusesService
    {
        Task<ICollection<Bus>> GetAllBusesByUserIdAsync(string userId);

        Task<Bus> GetBusByIdAsync(string busId);

        Task CreateAsync(CreateBusViewModel inputModel);

        Task EditAsync(EditBusViewModel busModel);

        Task DeleteAsync(Bus bus);
    }
}
