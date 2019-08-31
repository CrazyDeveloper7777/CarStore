using CarShop.Data.Models.Ads;
using CarShop.Web.ViewModels.TruckAds;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarShop.Services.TruckAds
{
    public interface ITruckAdsService
    {
        Task CreateAsync(CreateTruckAdViewModel viewModel);

        Task<ICollection<TruckAd>> GetAllByDealerIdAsync(string dealerId);

        Task<ICollection<TruckAd>> GetAllWithoutYoursAsync(string id);

        Task<TruckAd> GetByIdAsync(string adId);

        Task EditAsync(EditTruckAdViewModel inputModel);

        Task DeleteAsync(string id);
    }
}
