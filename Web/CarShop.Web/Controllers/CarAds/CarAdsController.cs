using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Data.Models.Ads;
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

            return this.Redirect("CarAds/MyCarAds");
        }

        public async Task<IActionResult> MyCarAds()
        {
            return this.View();
        }

        [HttpGet("/CarAds/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var carAd = await this.carAdsService.GetByIdAsync(id);
            var viewModel = AutoMapper.Mapper.Map<EditCarAdViewModel>(carAd);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarAdViewModel inputModel)
        {
            await this.carAdsService.EditAsync(inputModel);

            return this.RedirectToAction("MyCarAds");
        }

        [HttpGet("/CarAds/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.carAdsService.DeleteAsync(id);

            return this.RedirectToAction("MyCarAds");
        }

        [HttpGet("/CarAds/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var carAd = await this.carAdsService.GetByIdAsync(id);
            var viewModel = AutoMapper.Mapper.Map<CarAdDetailsViewModel>(carAd);

            return this.View(viewModel);
        }
    }
}