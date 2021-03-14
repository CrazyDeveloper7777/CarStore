using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.Motorcycles;

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

        public async Task CreateAsync(CreateMotorcycleViewModel inputModel)
        {
            var motorcycle = AutoMapperConfig.MapperInstance.Map<Motorcycle>(inputModel);
            motorcycle.Id = Guid.NewGuid().ToString();

            await this.motorcyclesRepository.AddAsync(motorcycle);
            await this.motorcyclesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Motorcycle motorcycle)
        {
            this.motorcyclesRepository.Delete(motorcycle);

            await this.motorcyclesRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditMotorcycleViewModel motorcycleModel)
        {
            var motorcycle = AutoMapperConfig.MapperInstance.Map<Motorcycle>(motorcycleModel);

            this.motorcyclesRepository.Update(motorcycle);
            await this.motorcyclesRepository.SaveChangesAsync();
        }

        public async Task<Motorcycle> GetMotorcycleByIdAsync(string motorcycleId)
        {
            var motorcycle = this.motorcyclesRepository.All().FirstOrDefault(c => c.Id == motorcycleId);
            return motorcycle;
        }
    }
}
