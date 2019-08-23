using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Buses
{
    public class BusesService : IBusesService
    {
        private readonly IDeletableEntityRepository<Bus> busesRepository;

        public BusesService(IDeletableEntityRepository<Bus> busesRepository)
        {
            this.busesRepository = busesRepository;
        }

        public async Task<ICollection<Bus>> GetAllBusesByUserId(string userId)
        {
            var buses = this.busesRepository.All().Where(t => t.OwnerId == userId).ToList();

            return buses;
        }
    }
}
