using CarShop.Data.Models.Ads;
using CarShop.Web.ViewModels.BusAds;
using CarShop.Web.ViewModels.MotorcyclesAds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.MotorcycleAds
{
    public interface IMotorcycleAdsService
    {
        Task CreateAsync(CreateMotorcycleAdViewModel viewModel);

        Task<ICollection<MotorcycleAd>> GetAllByDealerIdAsync(string dealerId);

        Task<ICollection<MotorcycleAd>> GetAllWithoutYoursAsync(string id);

        Task<MotorcycleAd> GetByIdAsync(string adId);

        Task EditAsync(EditMotorcycleAdViewModel inputModel);

        Task DeleteAsync(string id);
    }
}
