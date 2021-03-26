using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Services.Images;
using CarShop.Services.Mapping;
using CarShop.Services.SaveImagesService;
using CarShop.Web.ViewModels.MotorcyclesAds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Services.MotorcycleAds
{
    public class MotorcycleAdsService : IMotorcycleAdsService
    {
        private readonly IDeletableEntityRepository<MotorcycleAd> motorcycleAdsRepository;
        private readonly IImagesService imagesService;
        private readonly ISaveImagesService saveImagesService;

        public MotorcycleAdsService(IDeletableEntityRepository<MotorcycleAd> motorcycleAdsRepository, IImagesService imagesService, ISaveImagesService saveImagesService)
        {
            this.motorcycleAdsRepository = motorcycleAdsRepository;
            this.imagesService = imagesService;
            this.saveImagesService = saveImagesService;
        }

        public async Task CreateAsync(CreateMotorcycleAdViewModel viewModel)
        {
            var sanitizedImages = saveImagesService.SanitazeImages(viewModel.Images);
            viewModel.Images = sanitizedImages;
            var motorcycleAd = AutoMapperConfig.MapperInstance.Map<MotorcycleAd>(viewModel);
            motorcycleAd.Id = Guid.NewGuid().ToString();

            await this.saveImagesService.SaveImagesAsync(sanitizedImages);
            await this.motorcycleAdsRepository.AddAsync(motorcycleAd);
            await this.motorcycleAdsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var motorcycleAd = this.motorcycleAdsRepository
                .All()
                .FirstOrDefault(c => c.Id == id);

            await this.saveImagesService.DeleteImagesAsync(motorcycleAd.Images);
            await this.imagesService.DeleteAllByAdIdAsync(motorcycleAd.Id);
            this.motorcycleAdsRepository.Delete(motorcycleAd);
            await this.motorcycleAdsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditMotorcycleAdViewModel inputModel)
        {
            var motorcylceAd = AutoMapperConfig.MapperInstance.Map<MotorcycleAd>(inputModel);

            this.motorcycleAdsRepository.Update(motorcylceAd);
            await this.motorcycleAdsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<MotorcycleAd>> GetAllWithoutYoursAsync(string id)
        {
            var motorcycleAds = this.motorcycleAdsRepository
                .All()
                .Where(m => m.DealerId != id).ToList();

            return motorcycleAds;
        }

        public async Task<ICollection<MotorcycleAd>> GetAllByDealerIdAsync(string dealerId)
        {
            var motorcycleAd = this.motorcycleAdsRepository.All()
                .Where(c => c.DealerId == dealerId)
                .ToList();

            return motorcycleAd;
        }

        public async Task<MotorcycleAd> GetByIdAsync(string adId)
        {
            var motorcycleAd = this.motorcycleAdsRepository.All()
                .FirstOrDefault(ca => ca.Id == adId);

            return motorcycleAd;
        }
    }
}
