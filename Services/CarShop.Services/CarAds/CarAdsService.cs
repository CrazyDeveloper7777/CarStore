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
using CarShop.Services.SaveImagesService;
using CarShop.Web.ViewModels.CarAds;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services.CarAds
{
    public class CarAdsService : ICarAdsService
    {
        private readonly IDeletableEntityRepository<CarAd> carAdsRepository;
        private readonly IImagesService imagesService;
        private readonly ISaveImagesService saveImagesService;

        public CarAdsService(IDeletableEntityRepository<CarAd> carAdsRepository, IImagesService imagesService, ISaveImagesService saveImagesService)
        {
            this.carAdsRepository = carAdsRepository;
            this.imagesService = imagesService;
            this.saveImagesService = saveImagesService;
        }

        public async Task CreateAsync(CreateCarAdViewModel viewModel)
        {
            var sanitizedImages = saveImagesService.SanitazeImages(viewModel.Images);
            viewModel.Images = sanitizedImages;
            var carAd = AutoMapperConfig.MapperInstance.Map<CarAd>(viewModel);
            carAd.Id = Guid.NewGuid().ToString();

            await this.saveImagesService.SaveImagesAsync(sanitizedImages);
            await this.carAdsRepository.AddAsync(carAd);
            await this.carAdsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var carAd = this.carAdsRepository
                .All()
                .Include(c => c.Images)
                .FirstOrDefault(c => c.Id == id);

            await this.saveImagesService.DeleteImagesAsync(carAd.Images);
            await this.imagesService.DeleteAllByAdIdAsync(carAd.Id);
            this.carAdsRepository.Delete(carAd);
            await this.carAdsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditCarAdViewModel inputModel)
        {
            var carAd = AutoMapperConfig.MapperInstance.Map<CarAd>(inputModel);

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
