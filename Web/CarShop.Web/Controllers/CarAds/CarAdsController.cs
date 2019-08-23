using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Services.CarAds;
using CarShop.Web.ViewModels.CarAds;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.CarAds
{
    public class CarAdsController : Controller
    {
        private readonly ICarAdsService carAdsService;

        public CarAdsController(ICarAdsService carAdsService)
        {
            this.carAdsService = carAdsService;
        }


        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarAdViewModel createCarAdModel)
        {
            await this.carAdsService.CreateAsync(createCarAdModel);

            return this.Redirect("Ads/MyAds");
        }
    }
}