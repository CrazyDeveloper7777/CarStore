using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;
using CarShop.Web.ViewModels.Buses;
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

        public async Task<ICollection<Bus>> GetAllBusesByUserIdAsync(string userId)
        {
            var buses = this.busesRepository.All().Where(t => t.OwnerId == userId).ToList();

            return buses;
        }

        public async Task CreateAsync(CreateBusViewModel inputModel)
        {
            var bus = AutoMapper.Mapper.Map<Bus>(inputModel);

            await this.busesRepository.AddAsync(bus);
            await this.busesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bus bus)
        {
            this.busesRepository.Delete(bus);

            await this.busesRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditBusViewModel busModel)
        {
            var bus = AutoMapper.Mapper.Map<Bus>(busModel);

            this.busesRepository.Update(bus);
            await this.busesRepository.SaveChangesAsync();
        }

        public async Task<Bus> GetBusByIdAsync(string busId)
        {
            var bus = this.busesRepository.All().FirstOrDefault(c => c.Id == busId);
            return bus;
        }
    }
}
