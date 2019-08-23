using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;

namespace CarShop.Services.Trucks
{
    public class TrucksService : ITrucksService
    {
        private readonly IDeletableEntityRepository<Truck> trucksRepository;

        public TrucksService(IDeletableEntityRepository<Truck> trucksRepository)
        {
            this.trucksRepository = trucksRepository;
        }

        public async Task<ICollection<Truck>> GetAllTrucksByUserId(string userId)
        {
            var trucks = this.trucksRepository.All().Where(t => t.OwnerId == userId).ToList();

            return trucks;
        }
    }
}
