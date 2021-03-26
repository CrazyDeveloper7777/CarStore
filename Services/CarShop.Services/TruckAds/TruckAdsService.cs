using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Services.Images;
using CarShop.Services.Mapping;
using CarShop.Services.SaveImagesService;
using CarShop.Web.ViewModels.TruckAds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Services.TruckAds
{
    public class TruckAdsService : ITruckAdsService
    {
        private readonly IDeletableEntityRepository<TruckAd> truckAdsRepository;
        private readonly IImagesService imagesService;
        private readonly ISaveImagesService saveImagesService;

        public TruckAdsService(IDeletableEntityRepository<TruckAd> truckAdsRepository, IImagesService imagesService, ISaveImagesService saveImagesService)
        {
            this.truckAdsRepository = truckAdsRepository;
            this.imagesService = imagesService;
            this.saveImagesService = saveImagesService;
        }

        public async Task CreateAsync(CreateTruckAdViewModel viewModel)
        {
            var sanitizedImages = saveImagesService.SanitazeImages(viewModel.Images);
            viewModel.Images = sanitizedImages;
            var truckAd = AutoMapperConfig.MapperInstance.Map<TruckAd>(viewModel);
            truckAd.Id = Guid.NewGuid().ToString();

            await this.saveImagesService.SaveImagesAsync(sanitizedImages);
            await this.truckAdsRepository.AddAsync(truckAd);
            await this.truckAdsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var truckAd = this.truckAdsRepository
                .All()
                .FirstOrDefault(c => c.Id == id);

            await this.saveImagesService.DeleteImagesAsync(truckAd.Images);
            await this.imagesService.DeleteAllByAdIdAsync(truckAd.Id);
            this.truckAdsRepository.Delete(truckAd);
            await this.truckAdsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditTruckAdViewModel inputModel)
        {
            var truckAd = AutoMapperConfig.MapperInstance.Map<TruckAd>(inputModel);

            this.truckAdsRepository.Update(truckAd);
            await this.truckAdsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<TruckAd>> GetAllWithoutYoursAsync(string id)
        {
            var truckAds = this.truckAdsRepository
                .All()
                .Where(t => t.DealerId != id).ToList();

            return truckAds;
        }

        public async Task<ICollection<TruckAd>> GetAllByDealerIdAsync(string dealerId)
        {
            var truckAds = this.truckAdsRepository.All()
                .Where(c => c.DealerId == dealerId)
                .ToList();

            return truckAds;
        }

        public async Task<TruckAd> GetByIdAsync(string adId)
        {
            var truckAds = this.truckAdsRepository.All()
                .FirstOrDefault(ca => ca.Id == adId);

            return truckAds;
        }
    }
}
