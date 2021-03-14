using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Services.Mapping;
using CarShop.Services.TruckAds;
using CarShop.Web.ViewModels.TruckAds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.TruckAds
{
    public class TruckAdsController : Controller
    {
        private readonly ITruckAdsService truckAdsService;
        private readonly UserManager<ApplicationUser> userManager;

        public TruckAdsController(ITruckAdsService truckAdsService, UserManager<ApplicationUser> userManager)
        {
            this.truckAdsService = truckAdsService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(this.User);
            var viewModel = new CreateTruckAdViewModel();

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
        public async Task<IActionResult> Create(CreateTruckAdViewModel createTruckAdModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createTruckAdModel);
            }

            await this.truckAdsService.CreateAsync(createTruckAdModel);

            return this.RedirectToAction("MyTruckAds");
        }

        [Authorize]
        public async Task<IActionResult> MyTruckAds()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet("/TruckAds/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var truckAd = await this.truckAdsService.GetByIdAsync(id);
            var viewModel = AutoMapperConfig.MapperInstance.Map<EditTruckAdViewModel>(truckAd);

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
        public async Task<IActionResult> Edit(EditTruckAdViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.truckAdsService.EditAsync(inputModel);

            return this.RedirectToAction("MyTruckAds");
        }

        [Authorize]
        [HttpGet("/TruckAds/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.truckAdsService.DeleteAsync(id);

            return this.RedirectToAction("MyTruckAds");
        }

        [Authorize]
        [HttpGet("/TruckAds/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var truckAd = await this.truckAdsService.GetByIdAsync(id);
            var viewModel = AutoMapperConfig.MapperInstance.Map<TruckAdDetailsViewModel>(truckAd);

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

        public async Task<IActionResult> Search()
        {
            var truckAds = new List<TruckAd>();
            if(this.User.Identity.Name != null)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                truckAds = (List<TruckAd>)await this.truckAdsService.GetAllWithoutYoursAsync(user.Id);

                return this.View(truckAds);
            }

            truckAds = (List<TruckAd>)await this.truckAdsService.GetAllWithoutYoursAsync(null);

            return this.View(truckAds);
        }
    }
}