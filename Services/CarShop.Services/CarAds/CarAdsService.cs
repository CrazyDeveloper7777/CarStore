using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Ads;
using CarShop.Web.ViewModels.CarAds;

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
    }
}
