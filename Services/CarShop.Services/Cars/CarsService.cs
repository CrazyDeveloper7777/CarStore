using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;
using CarShop.Data.Models.Vehicles.Contracts;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.Cars;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services.Cars
{
    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carsRepository;

        public CarsService(IDeletableEntityRepository<Car> carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public async Task CreateAsync(CreateCarViewModel model)
        {
            var car = AutoMapper.Mapper.Map<Car>(model);

            await this.carsRepository.AddAsync(car);
            await this.carsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car car)
        {
            this.carsRepository.Delete(car);

            await this.carsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditCarViewModel carModel)
        {
            var car = AutoMapper.Mapper.Map<Car>(carModel);

            this.carsRepository.Update(car);
            await this.carsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<Car>> GetAllCarsByUserIdAsync(string userId)
        {
            var cars = this.carsRepository.All().Where(c => c.OwnerId == userId).ToList();

            return cars;
        }

        public async Task<Car> GetCarByIdAsync(string carId)
        {
            var car = this.carsRepository.All().FirstOrDefault(c => c.Id == carId);
            return car;
        }
    }
}
