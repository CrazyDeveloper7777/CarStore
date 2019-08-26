using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Web.ViewModels.CarAds;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services.CarAds
{
    public class CarAdsService : ICarAdsService
    {
        private readonly IDeletableEntityRepository<CarAd> carAdsRepository;

        public CarAdsService(IDeletableEntityRepository<CarAd> carAdsRepository)
        {
            this.carAdsRepository = carAdsRepository;
        }

        public async Task CreateAsync(CreateCarAdViewModel viewModel)
        {
            var carAd = AutoMapper.Mapper.Map<CarAd>(viewModel);

            if (viewModel.Image1.Url != null)
            {
                carAd.Images.Add(viewModel.Image1);
            }

            if (viewModel.Image2.Url != null)
            {
                carAd.Images.Add(viewModel.Image2);
            }

            if (viewModel.Image3.Url != null)
            {
                carAd.Images.Add(viewModel.Image3);
            }

            if (viewModel.Image4.Url != null)
            {
                carAd.Images.Add(viewModel.Image4);
            }

            if (viewModel.Image5.Url != null)
            {
                carAd.Images.Add(viewModel.Image5);
            }

            if (viewModel.Image6.Url != null)
            {
                carAd.Images.Add(viewModel.Image6);
            }

            if (viewModel.Image7.Url != null)
            {
                carAd.Images.Add(viewModel.Image7);
            }

            if (viewModel.Image8.Url != null)
            {
                carAd.Images.Add(viewModel.Image8);
            }

            if (viewModel.Image9.Url != null)
            {
                carAd.Images.Add(viewModel.Image9);
            }

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
            var carAd = AutoMapper.Mapper.Map<CarAd>(inputModel);
            this.carAdsRepository.Update(carAd);

            await this.carAdsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<CarAd>> GetAllByDealerIdAsync(string dealerId)
        {
            var carAds = this.carAdsRepository.All()
                .Include(c => c.Car).Where(c => c.DealerId == dealerId)
                .ToList();

            return carAds;
        }

        public async Task<CarAd> GetByIdAsync(string adId)
        {
            var carAd = this.carAdsRepository.All()
                .Include(c => c.Car)
                .FirstOrDefault(ca => ca.Id == adId);

            return carAd;
        }
    }
}
