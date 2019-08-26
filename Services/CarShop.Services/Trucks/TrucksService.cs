using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;
using CarShop.Web.ViewModels.Trucks;

namespace CarShop.Services.Trucks
{
    public class TrucksService : ITrucksService
    {
        private readonly IDeletableEntityRepository<Truck> trucksRepository;

        public TrucksService(IDeletableEntityRepository<Truck> trucksRepository)
        {
            this.trucksRepository = trucksRepository;
        }

        public async Task CreateAsync(CreateTruckViewModel inputModel)
        {
            var truck = AutoMapper.Mapper.Map<Truck>(inputModel);

            await this.trucksRepository.AddAsync(truck);
            await this.trucksRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Truck truck)
        {
            this.trucksRepository.Delete(truck);

            await this.trucksRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditTruckViewModel truckModel)
        {
            var truck = AutoMapper.Mapper.Map<Truck>(truckModel);

            this.trucksRepository.Update(truck);
            await this.trucksRepository.SaveChangesAsync();
        }

        public async Task<ICollection<Truck>> GetAllTrucksByUserIdAsync(string userId)
        {
            var trucks = this.trucksRepository.All().Where(t => t.OwnerId == userId).ToList();

            return trucks;
        }

        public async Task<Truck> GetTruckByIdAsync(string truckId)
        {
            var truck = this.trucksRepository.All().FirstOrDefault(c => c.Id == truckId);
            return truck;
        }
    }
}
