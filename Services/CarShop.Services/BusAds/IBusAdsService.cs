using CarShop.Data.Models.Ads;
using CarShop.Web.ViewModels.BusAds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.BusAds
{
    public interface IBusAdsService
    {
        Task CreateAsync(CreateBusAdViewModel viewModel);

        Task<ICollection<BusAd>> GetAllByDealerIdAsync(string dealerId);

        Task<BusAd> GetByIdAsync(string adId);

        Task EditAsync(EditBusAdViewModel inputModel);

        Task DeleteAsync(string id);
    }
}
