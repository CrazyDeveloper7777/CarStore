using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Services.Images;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.CarAds;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services.CarAds
{
    public class CarAdsService : ICarAdsService
    {
        private readonly IDeletableEntityRepository<CarAd> carAdsRepository;
        private readonly IImagesService imagesService;

        public CarAdsService(IDeletableEntityRepository<CarAd> carAdsRepository, IImagesService imagesService)
        {
            this.carAdsRepository = carAdsRepository;
            this.imagesService = imagesService;
        }

        public async Task CreateAsync(CreateCarAdViewModel viewModel)
        {
            var carAd = AutoMapperConfig.MapperInstance.Map<CarAd>(viewModel);
            carAd.Id = Guid.NewGuid().ToString();

            carAd.Images.Add(viewModel.Image1);
            carAd.Images.Add(viewModel.Image2);
            carAd.Images.Add(viewModel.Image3);
            carAd.Images.Add(viewModel.Image4);
            carAd.Images.Add(viewModel.Image5);
            carAd.Images.Add(viewModel.Image6);
            carAd.Images.Add(viewModel.Image7);
            carAd.Images.Add(viewModel.Image8);
            carAd.Images.Add(viewModel.Image9);

            await this.carAdsRepository.AddAsync(carAd);
            await this.carAdsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var carAd = this.carAdsRepository.All().FirstOrDefault(c => c.Id == id);

            this.carAdsRepository.Delete(carAd);
            await this.carAdsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditCarAdViewModel inputModel)
        {
            var carAd = AutoMapperConfig.MapperInstance.Map<CarAd>(inputModel);

            await this.imagesService.DeleteAllByAdIdAsync(inputModel.Id);

            carAd.Images.Add(inputModel.Image1);
            carAd.Images.Add(inputModel.Image2);
            carAd.Images.Add(inputModel.Image3);
            carAd.Images.Add(inputModel.Image4);
            carAd.Images.Add(inputModel.Image5);
            carAd.Images.Add(inputModel.Image6);
            carAd.Images.Add(inputModel.Image7);
            carAd.Images.Add(inputModel.Image8);
            carAd.Images.Add(inputModel.Image9);

            this.carAdsRepository.Update(carAd);
            await this.carAdsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<CarAd>> GetAllWithoutYoursAsync(string id)
        {
            var carAds = this.carAdsRepository
                .All()
                .Include(c => c.Car)
                .Include(i => i.Images)
                .Where(c => c.DealerId != id).ToList();

            return carAds;
        }

        public async Task<ICollection<CarAd>> GetAllByDealerIdAsync(string dealerId)
        {
            var carAds = this.carAdsRepository.All()
                .Include(c => c.Car)
                .Include(p => p.Images)
                .Where(c => c.DealerId == dealerId)
                .ToList();

            return carAds;
        }

        public async Task<CarAd> GetByIdAsync(string adId)
        {
            var carAd = this.carAdsRepository.All()
                .Include(c => c.Car)
                .Include(p => p.Images)
                .FirstOrDefault(ca => ca.Id == adId);

            return carAd;
        }
    }
}
