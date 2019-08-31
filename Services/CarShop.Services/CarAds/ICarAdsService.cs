using CarShop.Data.Models.Ads;
using CarShop.Web.ViewModels.CarAds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.CarAds
{
    public interface ICarAdsService
    {
        Task CreateAsync(CreateCarAdViewModel viewModel);

        Task<ICollection<CarAd>> GetAllByDealerIdAsync(string dealerId);

        Task<ICollection<CarAd>> GetAllWithoutYoursAsync(string id);


        Task<CarAd> GetByIdAsync(string adId);

        Task EditAsync(EditCarAdViewModel inputModel);

        Task DeleteAsync(string id);
    }
}
