using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Services.Images;
using CarShop.Services.Mapping;
using CarShop.Services.SaveImagesService;
using CarShop.Web.ViewModels.BusAds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.BusAds
{
    public class BusAdsService : IBusAdsService
    {
        private readonly IDeletableEntityRepository<BusAd> busAdsRepository;
        private readonly IImagesService imagesService;
        private readonly ISaveImagesService saveImagesService;

        public BusAdsService(IDeletableEntityRepository<BusAd> busAdsRepository, IImagesService imagesService, ISaveImagesService saveImagesService)
        {
            this.busAdsRepository = busAdsRepository;
            this.imagesService = imagesService;
            this.saveImagesService = saveImagesService;
        }

        public async Task CreateAsync(CreateBusAdViewModel viewModel)
        {
            var sanitizedImages = saveImagesService.SanitazeImages(viewModel.Images);
            viewModel.Images = sanitizedImages;
            var busAd = AutoMapperConfig.MapperInstance.Map<BusAd>(viewModel);
            busAd.Id = Guid.NewGuid().ToString();

            await this.saveImagesService.SaveImagesAsync(sanitizedImages);
            await this.busAdsRepository.AddAsync(busAd);
            await this.busAdsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var busAd = this.busAdsRepository
                .All()
                .FirstOrDefault(c => c.Id == id);

            await this.saveImagesService.DeleteImagesAsync(busAd.Images);
            await this.imagesService.DeleteAllByAdIdAsync(busAd.Id);
            this.busAdsRepository.Delete(busAd);
            await this.busAdsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditBusAdViewModel inputModel)
        {
            var busAd = AutoMapperConfig.MapperInstance.Map<BusAd>(inputModel);

            this.busAdsRepository.Update(busAd);
            await this.busAdsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<BusAd>> GetAllWithoutYoursAsync(string id)
        {
            var busAds = this.busAdsRepository
                .All()
                .Where(b => b.DealerId != id).ToList();

            return busAds;
        }

        public async Task<ICollection<BusAd>> GetAllByDealerIdAsync(string dealerId)
        {
            var busAds = this.busAdsRepository.All()
                .Where(c => c.DealerId == dealerId)
                .ToList();

            return busAds;
        }

        public async Task<BusAd> GetByIdAsync(string adId)
        {
            var busAd = this.busAdsRepository.All()
                .FirstOrDefault(ca => ca.Id == adId);

            return busAd;
        }
    }
}
