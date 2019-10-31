using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Services.CarAds;
using CarShop.Services.Images;
using CarShop.Services.Users;
using CarShop.Web.ViewModels.CarAds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.CarAds
{
    public class CarAdsController : Controller
    {
        private readonly ICarAdsService carAdsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CarAdsController(ICarAdsService carAdsService, UserManager<ApplicationUser> userManager)
        {
            this.carAdsService = carAdsService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(this.User);
            var viewModel = new CreateCarAdViewModel();

            if (user.PhoneNumber != null)
            {
                viewModel.PhoneNumber = user.PhoneNumber;
            }

            if (user.PhoneNumber2 != null)
            {
                viewModel.PhoneNumber2 = user.PhoneNumber2;
            }

            if (user.PhoneNumber3 != null)
            {
                viewModel.PhoneNumber3 = user.PhoneNumber3;
            }

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateCarAdViewModel createCarAdModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createCarAdModel);
            }

            await this.carAdsService.CreateAsync(createCarAdModel);

            return this.RedirectToAction("MyCarAds");
        }

        [Authorize]
        public async Task<IActionResult> MyCarAds()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet("/CarAds/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var carAd = await this.carAdsService.GetByIdAsync(id);
            var viewModel = AutoMapper.Mapper.Map<EditCarAdViewModel>(carAd);

            viewModel.Image1 = ((List<Image>)carAd.Images)[0];
            viewModel.Image2 = ((List<Image>)carAd.Images)[1];
            viewModel.Image3 = ((List<Image>)carAd.Images)[2];
            viewModel.Image4 = ((List<Image>)carAd.Images)[3];
            viewModel.Image5 = ((List<Image>)carAd.Images)[4];
            viewModel.Image6 = ((List<Image>)carAd.Images)[5];
            viewModel.Image7 = ((List<Image>)carAd.Images)[6];
            viewModel.Image8 = ((List<Image>)carAd.Images)[7];
            viewModel.Image9 = ((List<Image>)carAd.Images)[8];

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditCarAdViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.carAdsService.EditAsync(inputModel);

            return this.RedirectToAction("MyCarAds");
        }

        [Authorize]
        [HttpGet("/CarAds/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.carAdsService.DeleteAsync(id);

            return this.RedirectToAction("MyCarAds");
        }

        [Authorize]
        [HttpGet("/CarAds/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var carAd = await this.carAdsService.GetByIdAsync(id);
            var viewModel = AutoMapper.Mapper.Map<CarAdDetailsViewModel>(carAd);

            viewModel.Image1 = ((List<Image>)carAd.Images)[0];
            viewModel.Image2 = ((List<Image>)carAd.Images)[1];
            viewModel.Image3 = ((List<Image>)carAd.Images)[2];
            viewModel.Image4 = ((List<Image>)carAd.Images)[3];
            viewModel.Image5 = ((List<Image>)carAd.Images)[4];
            viewModel.Image6 = ((List<Image>)carAd.Images)[5];
            viewModel.Image7 = ((List<Image>)carAd.Images)[6];
            viewModel.Image8 = ((List<Image>)carAd.Images)[7];
            viewModel.Image9 = ((List<Image>)carAd.Images)[8];

            return this.View(viewModel);
        }

        public async Task<IActionResult> Search()
        {
            var carAds = new List<CarAd>();
            if (this.User.Identity.Name != null)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                carAds = (List<CarAd>)await this.carAdsService.GetAllWithoutYoursAsync(user.Id);

                return this.View(carAds);
            }

            carAds = (List<CarAd>)await this.carAdsService.GetAllWithoutYoursAsync(null);

            return this.View(carAds);
        }
    }
}