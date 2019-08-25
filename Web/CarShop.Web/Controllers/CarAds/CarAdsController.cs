using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Services.CarAds;
using CarShop.Services.Users;
using CarShop.Web.ViewModels.CarAds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.CarAds
{
    public class CarAdsController : Controller
    {
        private readonly ICarAdsService carAdsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;

        public CarAdsController(ICarAdsService carAdsService, UserManager<ApplicationUser> userManager)
        {
            this.carAdsService = carAdsService;
            this.userManager = userManager;
        }


        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(this.User);
            var viewModel = new CreateCarAdViewModel();

            if(user.PhoneNumber != null)
            {
                viewModel.PhoneNumber = user.PhoneNumber;
            }

            if (user.PhoneNumber2 != null)
            {
                viewModel.PhoneNumber = user.PhoneNumber2;
            }

            if (user.PhoneNumber3 != null)
            {
                viewModel.PhoneNumber = user.PhoneNumber3;
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarAdViewModel createCarAdModel)
        {
            await this.carAdsService.CreateAsync(createCarAdModel);

            return this.Redirect("Ads/MyAds");
        }
    }
}