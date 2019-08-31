using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Services.Images;
using CarShop.Web.ViewModels.BusAds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.BusAds
{
    public class BusAdsService : IBusAdsService
    {
        private readonly IDeletableEntityRepository<BusAd> busAdsRepository;
        private readonly IImagesService imagesService;

        public BusAdsService(IDeletableEntityRepository<BusAd> busAdsRepository, IImagesService imagesService)
        {
            this.busAdsRepository = busAdsRepository;
            this.imagesService = imagesService;
        }

        public async Task CreateAsync(CreateBusAdViewModel viewModel)
        {
            var busAd = AutoMapper.Mapper.Map<BusAd>(viewModel);

            busAd.Images.Add(viewModel.Image1);
            busAd.Images.Add(viewModel.Image2);
            busAd.Images.Add(viewModel.Image3);
            busAd.Images.Add(viewModel.Image4);
            busAd.Images.Add(viewModel.Image5);
            busAd.Images.Add(viewModel.Image6);
            busAd.Images.Add(viewModel.Image7);
            busAd.Images.Add(viewModel.Image8);
            busAd.Images.Add(viewModel.Image9);

            await this.busAdsRepository.AddAsync(busAd);
            await this.busAdsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var busAd = this.busAdsRepository.All().FirstOrDefault(c => c.Id == id);

            this.busAdsRepository.Delete(busAd);
            await this.busAdsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(EditBusAdViewModel inputModel)
        {
            var busAd = AutoMapper.Mapper.Map<BusAd>(inputModel);

            await this.imagesService.DeleteAllByAdIdAsync(inputModel.Id);

            busAd.Images.Add(inputModel.Image1);
            busAd.Images.Add(inputModel.Image2);
            busAd.Images.Add(inputModel.Image3);
            busAd.Images.Add(inputModel.Image4);
            busAd.Images.Add(inputModel.Image5);
            busAd.Images.Add(inputModel.Image6);
            busAd.Images.Add(inputModel.Image7);
            busAd.Images.Add(inputModel.Image8);
            busAd.Images.Add(inputModel.Image9);

            this.busAdsRepository.Update(busAd);

            await this.busAdsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<BusAd>> GetAllByDealerIdAsync(string dealerId)
        {
            var busAds = this.busAdsRepository.All()
                .Include(b => b.Bus)
                .Include(i => i.Images)
                .Where(c => c.DealerId == dealerId)
                .ToList();

            return busAds;
        }

        public async Task<BusAd> GetByIdAsync(string adId)
        {
            var busAd = this.busAdsRepository.All()
                .Include(c => c.Bus)
                .Include(i => i.Images)
                .FirstOrDefault(ca => ca.Id == adId);

            return busAd;
        }
    }
}
