using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;

namespace CarShop.Services.Motorcycles
{
    public class MotorcyclesService : IMotorcyclesService
    {
        private readonly IDeletableEntityRepository<Motorcycle> motorcyclesRepository;

        public MotorcyclesService (IDeletableEntityRepository<Motorcycle> motorcyclesRepository)
        {
            this.motorcyclesRepository = motorcyclesRepository;
        }

        public async Task<ICollection<Motorcycle>> GetAllMotorcyclesByUserId(string userId)
        {
            var motorcycles = this.motorcyclesRepository.All().Where(t => t.OwnerId == userId).ToList();

            return motorcycles;
        }
    }
}
