using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Vehicles
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IDeletableEntityRepository<Vehicle> vehiclesRepository;

        public VehiclesService(IDeletableEntityRepository<Vehicle> vehiclesRepository)
        {
            this.vehiclesRepository = vehiclesRepository;
        }

        public async Task<ICollection<Vehicle>> GetAllVehiclesByUserIdAsync(string userId)
        {
            var vehicles = this.vehiclesRepository.All().Where(v => v.OwnerId == userId).ToList();

            return vehicles;
        }
    }
}
