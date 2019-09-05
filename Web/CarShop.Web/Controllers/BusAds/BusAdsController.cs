using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Services.BusAds;
using CarShop.Web.ViewModels;
using CarShop.Web.ViewModels.BusAds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.BusAds
{
    public class BusAdsController : Controller
    {
        private readonly IBusAdsService busAdsService;
        private readonly UserManager<ApplicationUser> userManager;

        public BusAdsController(IBusAdsService busAdsService, UserManager<ApplicationUser> userManager)
        {
            this.busAdsService = busAdsService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(this.User);
            var viewModel = new CreateBusAdViewModel();

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
        public async Task<IActionResult> Create(CreateBusAdViewModel createBusAdViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createBusAdViewModel);
            }

            await this.busAdsService.CreateAsync(createBusAdViewModel);

            return this.RedirectToAction("MyBusAds");
        }

        public async Task<IActionResult> MyBusAds()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet("/BusAds/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var busAd = await this.busAdsService.GetByIdAsync(id);
            var viewModel = AutoMapper.Mapper.Map<EditBusAdViewModel>(busAd);

            viewModel.Image1 = ((List<Image>)busAd.Images)[0];
            viewModel.Image2 = ((List<Image>)busAd.Images)[1];
            viewModel.Image3 = ((List<Image>)busAd.Images)[2];
            viewModel.Image4 = ((List<Image>)busAd.Images)[3];
            viewModel.Image5 = ((List<Image>)busAd.Images)[4];
            viewModel.Image6 = ((List<Image>)busAd.Images)[5];
            viewModel.Image7 = ((List<Image>)busAd.Images)[6];
            viewModel.Image8 = ((List<Image>)busAd.Images)[7];
            viewModel.Image9 = ((List<Image>)busAd.Images)[8];

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditBusAdViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.busAdsService.EditAsync(inputModel);

            return this.RedirectToAction("MyBusAds");
        }

        [Authorize]
        [HttpGet("/BusAds/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.busAdsService.DeleteAsync(id);

            return this.RedirectToAction("MyBusAds");
        }

        [Authorize]
        [HttpGet("/BusAds/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var busAd = await this.busAdsService.GetByIdAsync(id);
            var viewModel = AutoMapper.Mapper.Map<BusAdDetailsViewModel>(busAd);

            viewModel.Image1 = ((List<Image>)busAd.Images)[0];
            viewModel.Image2 = ((List<Image>)busAd.Images)[1];
            viewModel.Image3 = ((List<Image>)busAd.Images)[2];
            viewModel.Image4 = ((List<Image>)busAd.Images)[3];
            viewModel.Image5 = ((List<Image>)busAd.Images)[4];
            viewModel.Image6 = ((List<Image>)busAd.Images)[5];
            viewModel.Image7 = ((List<Image>)busAd.Images)[6];
            viewModel.Image8 = ((List<Image>)busAd.Images)[7];
            viewModel.Image9 = ((List<Image>)busAd.Images)[8];

            return this.View(viewModel);
        }

        public async Task<IActionResult> Search()
        {
            var busAds = new List<BusAd>();
            if (this.User.Identity.Name != null)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                busAds = (List<BusAd>)await this.busAdsService.GetAllWithoutYoursAsync(user.Id);

                return this.View(busAds);
            }

            busAds = (List<BusAd>)await this.busAdsService.GetAllWithoutYoursAsync(null);

            return this.View(busAds);
        }
    }
}