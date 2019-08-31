using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Services.Images;
using CarShop.Web.ViewModels.TruckAds;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Services.TruckAds
{
    public class TruckAdsService : ITruckAdsService
    {
        private readonly IDeletableEntityRepository<TruckAd> truckAdsRepository;
        private readonly IImagesService imagesService;

        public TruckAdsService(IDeletableEntityRepository<TruckAd> truckAdsRepository, IImagesService imagesService)
        {
            this.truckAdsRepository = truckAdsRepository;
            this.imagesService = imagesService;
        }

        public async Task CreateAsync(CreateTruckAdViewModel viewModel)
        {
            var truckAd = AutoMapper.Mapper.Map<TruckAd>(viewModel);

            truckAd.Images.Add(viewModel.Image1);
            truckAd.Images.Add(viewModel.Image2);
            truckAd.Images.Add(viewModel.Image3);
            truckAd.Images.Add(viewModel.Image4);
            truckAd.Images.Add(viewModel.Image5);
            truckAd.Images.Add(viewModel.Image6);
            truckAd.Images.Add(viewModel.Image7);
            truckAd.Images.Add(viewModel.Image8);
            truckAd.Images.Add(viewModel.Image9);

            await this.truckAdsRepository.AddAsync(truckAd);
            await this.truckAdsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var truckAd = this.truckAdsRepository.All().FirstOrDefault(c => c.Id == id);

            this.truckAdsRepository.Delete(truckAd);
            await this.truckAdsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditTruckAdViewModel inputModel)
        {
            var truckAd = AutoMapper.Mapper.Map<TruckAd>(inputModel);

            await this.imagesService.DeleteAllByAdIdAsync(inputModel.Id);

            truckAd.Images.Add(inputModel.Image1);
            truckAd.Images.Add(inputModel.Image2);
            truckAd.Images.Add(inputModel.Image3);
            truckAd.Images.Add(inputModel.Image4);
            truckAd.Images.Add(inputModel.Image5);
            truckAd.Images.Add(inputModel.Image6);
            truckAd.Images.Add(inputModel.Image7);
            truckAd.Images.Add(inputModel.Image8);
            truckAd.Images.Add(inputModel.Image9);

            this.truckAdsRepository.Update(truckAd);

            await this.truckAdsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<TruckAd>> GetAllByDealerIdAsync(string dealerId)
        {
            var truckAds = this.truckAdsRepository.All()
                .Include(t => t.Truck)
                .Include(i => i.Images)
                .Where(c => c.DealerId == dealerId)
                .ToList();

            return truckAds;
        }

        public async Task<TruckAd> GetByIdAsync(string adId)
        {
            var truckAds = this.truckAdsRepository.All()
                .Include(t => t.Truck)
                .Include(i => i.Images)
                .FirstOrDefault(ca => ca.Id == adId);

            return truckAds;
        }
    }
}
