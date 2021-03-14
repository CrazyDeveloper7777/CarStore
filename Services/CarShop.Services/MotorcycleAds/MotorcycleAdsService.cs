using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Services.Images;
using CarShop.Services.Mapping;
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

        public MotorcycleAdsService(IDeletableEntityRepository<MotorcycleAd> motorcycleAdsRepository, IImagesService imagesService)
        {
            this.motorcycleAdsRepository = motorcycleAdsRepository;
            this.imagesService = imagesService;
        }

        public async Task CreateAsync(CreateMotorcycleAdViewModel viewModel)
        {
            var motorcycleAd = AutoMapperConfig.MapperInstance.Map<MotorcycleAd>(viewModel);
            motorcycleAd.Id = Guid.NewGuid().ToString();

            motorcycleAd.Images.Add(viewModel.Image1);
            motorcycleAd.Images.Add(viewModel.Image2);
            motorcycleAd.Images.Add(viewModel.Image3);
            motorcycleAd.Images.Add(viewModel.Image4);
            motorcycleAd.Images.Add(viewModel.Image5);
            motorcycleAd.Images.Add(viewModel.Image6);
            motorcycleAd.Images.Add(viewModel.Image7);
            motorcycleAd.Images.Add(viewModel.Image8);
            motorcycleAd.Images.Add(viewModel.Image9);

            await this.motorcycleAdsRepository.AddAsync(motorcycleAd);
            await this.motorcycleAdsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var motorcycleAd = this.motorcycleAdsRepository.All().FirstOrDefault(c => c.Id == id);

            this.motorcycleAdsRepository.Delete(motorcycleAd);
            await this.motorcycleAdsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditMotorcycleAdViewModel inputModel)
        {
            var motorcylceAd = AutoMapperConfig.MapperInstance.Map<MotorcycleAd>(inputModel);

            await this.imagesService.DeleteAllByAdIdAsync(inputModel.Id);

            motorcylceAd.Images.Add(inputModel.Image1);
            motorcylceAd.Images.Add(inputModel.Image2);
            motorcylceAd.Images.Add(inputModel.Image3);
            motorcylceAd.Images.Add(inputModel.Image4);
            motorcylceAd.Images.Add(inputModel.Image5);
            motorcylceAd.Images.Add(inputModel.Image6);
            motorcylceAd.Images.Add(inputModel.Image7);
            motorcylceAd.Images.Add(inputModel.Image8);
            motorcylceAd.Images.Add(inputModel.Image9);

            this.motorcycleAdsRepository.Update(motorcylceAd);

            await this.motorcycleAdsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<MotorcycleAd>> GetAllWithoutYoursAsync(string id)
        {
            var motorcycleAds = this.motorcycleAdsRepository
                .All()
                .Include(m => m.Motorcycle)
                .Include(i => i.Images)
                .Where(m => m.DealerId != id).ToList();

            return motorcycleAds;
        }

        public async Task<ICollection<MotorcycleAd>> GetAllByDealerIdAsync(string dealerId)
        {
            var motorcycleAd = this.motorcycleAdsRepository.All()
                .Include(m => m.Motorcycle)
                .Include(i => i.Images)
                .Where(c => c.DealerId == dealerId)
                .ToList();

            return motorcycleAd;
        }

        public async Task<MotorcycleAd> GetByIdAsync(string adId)
        {
            var motorcycleAd = this.motorcycleAdsRepository.All()
                .Include(m => m.Motorcycle)
                .Include(i => i.Images)
                .FirstOrDefault(ca => ca.Id == adId);

            return motorcycleAd;
        }
    }
}
