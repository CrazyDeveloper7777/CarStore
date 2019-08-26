using CarShop.Services.Trucks;
using CarShop.Web.ViewModels.Trucks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Web.Controllers
{
    public class TrucksController : BaseController
    {
        private readonly ITrucksService trucksService;

        public TrucksController(ITrucksService trucksService)
        {
            this.trucksService = trucksService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateTruckViewModel inputModel)
        {
            this.trucksService.CreateAsync(inputModel);

            return this.RedirectToAction("MyTrucks");
        }

        [Authorize]
        [HttpGet("/Trucks/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var truck = await this.trucksService.GetTruckByIdAsync(id);
            var truckModel = AutoMapper.Mapper.Map<EditTruckViewModel>(truck);
            truckModel.Year = truck.ManufacturedOn.Year;
            truckModel.Month = truck.ManufacturedOn.Month;

            return this.View(truckModel);
        }

        [Authorize]
        [HttpPost("/Trucks/Edit/{id}")]
        public async Task<IActionResult> Edit(EditTruckViewModel truckModel)
        {
            truckModel.ManufacturedOn = new DateTime(truckModel.Year, truckModel.Month, 1);
            await this.trucksService.EditAsync(truckModel);

            return this.RedirectToAction("MyTrucks");
        }

        [Authorize]
        [HttpGet("/Trucks/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var truck = await this.trucksService.GetTruckByIdAsync(id);

            await this.trucksService.DeleteAsync(truck);

            var message = "You have deleted your car successfully.";
            return this.Redirect($"/Trucks/MyTrucks?message={message}");
        }

        [Authorize]
        [HttpGet("/Trucks/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var truck = await this.trucksService.GetTruckByIdAsync(id);
            var truckModel = AutoMapper.Mapper.Map<DetailsTruckViewModel>(truck);

            return this.View(truckModel);
        }

        [Authorize]
        public IActionResult MyTrucks()
        {
            return this.View();
        }
    }
}
