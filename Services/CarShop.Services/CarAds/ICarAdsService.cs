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
    }
}
