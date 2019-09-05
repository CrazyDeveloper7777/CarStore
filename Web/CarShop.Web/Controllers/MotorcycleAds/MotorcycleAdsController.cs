using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Services.MotorcycleAds;
using CarShop.Web.ViewModels.MotorcyclesAds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.MotorcycleAds
{
    public class MotorcycleAdsController : Controller
    {
        private readonly IMotorcycleAdsService motorcycleAdsService;
        private readonly UserManager<ApplicationUser> userManager;

        public MotorcycleAdsController(IMotorcycleAdsService motorcycleAdsService, UserManager<ApplicationUser> userManager)
        {
            this.motorcycleAdsService = motorcycleAdsService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(this.User);
            var viewModel = new CreateMotorcycleAdViewModel();

            if (user.PhoneNumber != null)
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

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateMotorcycleAdViewModel createMotorcycleAdModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createMotorcycleAdModel);
            }

            await this.motorcycleAdsService.CreateAsync(createMotorcycleAdModel);

            return this.RedirectToAction("MyMotorcycleAds");
        }

        [Authorize]
        public async Task<IActionResult> MyMotorcycleAds()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet("/MotorcycleAds/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var truckAd = await this.motorcycleAdsService.GetByIdAsync(id);
            var viewModel = AutoMapper.Mapper.Map<EditMotorcycleAdViewModel>(truckAd);

            viewModel.Image1 = ((List<Image>)truckAd.Images)[0];
            viewModel.Image2 = ((List<Image>)truckAd.Images)[1];
            viewModel.Image3 = ((List<Image>)truckAd.Images)[2];
            viewModel.Image4 = ((List<Image>)truckAd.Images)[3];
            viewModel.Image5 = ((List<Image>)truckAd.Images)[4];
            viewModel.Image6 = ((List<Image>)truckAd.Images)[5];
            viewModel.Image7 = ((List<Image>)truckAd.Images)[6];
            viewModel.Image8 = ((List<Image>)truckAd.Images)[7];
            viewModel.Image9 = ((List<Image>)truckAd.Images)[8];

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditMotorcycleAdViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.motorcycleAdsService.EditAsync(inputModel);

            return this.RedirectToAction("MyMotorcycleAds");
        }

        [Authorize]
        [HttpGet("/MotorcycleAds/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.motorcycleAdsService.DeleteAsync(id);

            return this.RedirectToAction("MyMotorcycleAds");
        }

        [Authorize]
        [HttpGet("/MotorcycleAds/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var motorcycleAd = await this.motorcycleAdsService.GetByIdAsync(id);
            var viewModel = AutoMapper.Mapper.Map<MotorcycleAdDetailsViewModel>(motorcycleAd);

            viewModel.Image1 = ((List<Image>)motorcycleAd.Images)[0];
            viewModel.Image2 = ((List<Image>)motorcycleAd.Images)[1];
            viewModel.Image3 = ((List<Image>)motorcycleAd.Images)[2];
            viewModel.Image4 = ((List<Image>)motorcycleAd.Images)[3];
            viewModel.Image5 = ((List<Image>)motorcycleAd.Images)[4];
            viewModel.Image6 = ((List<Image>)motorcycleAd.Images)[5];
            viewModel.Image7 = ((List<Image>)motorcycleAd.Images)[6];
            viewModel.Image8 = ((List<Image>)motorcycleAd.Images)[7];
            viewModel.Image9 = ((List<Image>)motorcycleAd.Images)[8];

            return this.View(viewModel);
        }

        public async Task<IActionResult> Search()
        {
            var motorcycleAds = new List<MotorcycleAd>();
            if (this.User.Identity.Name != null)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                motorcycleAds = (List<MotorcycleAd>)await this.motorcycleAdsService.GetAllWithoutYoursAsync(user.Id);

                return this.View(motorcycleAds);
            }

            motorcycleAds = (List<MotorcycleAd>)await this.motorcycleAdsService.GetAllWithoutYoursAsync(null);

            return this.View(motorcycleAds);
        }
    }
}