using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Vehicles;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.Cars;

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
    }
}
