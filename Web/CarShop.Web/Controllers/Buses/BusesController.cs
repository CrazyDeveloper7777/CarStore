using CarShop.Services.Buses;
using CarShop.Web.ViewModels.Buses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Web.Controllers.Buses
{
    public class BusesController : BaseController
    {
        private readonly IBusesService busesService;

        public BusesController(IBusesService busesService)
        {
            this.busesService = busesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBusViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.busesService.CreateAsync(inputModel);

            return this.RedirectToAction("MyBuses");
        }

        [Authorize]
        [HttpGet("/Buses/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var bus = await this.busesService.GetBusByIdAsync(id);
            var busModel = AutoMapper.Mapper.Map<EditBusViewModel>(bus);
            busModel.Year = bus.ManufacturedOn.Year;
            busModel.Month = bus.ManufacturedOn.Month;

            return this.View(busModel);
        }

        [Authorize]
        [HttpPost("/Buses/Edit/{id}")]
        public async Task<IActionResult> Edit(EditBusViewModel busModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(busModel);
            }

            busModel.ManufacturedOn = new DateTime(busModel.Year, busModel.Month, 1);
            await this.busesService.EditAsync(busModel);

            return this.RedirectToAction("MyBuses");
        }

        [Authorize]
        [HttpGet("/Buses/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var bus = await this.busesService.GetBusByIdAsync(id);

            await this.busesService.DeleteAsync(bus);

            var message = "You have deleted your car successfully.";
            return this.Redirect($"/Buses/MyBuses?message={message}");
        }

        [Authorize]
        [HttpGet("/Buses/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var bus = await this.busesService.GetBusByIdAsync(id);
            var busModel = AutoMapper.Mapper.Map<DetailsBusViewModel>(bus);

            return this.View(busModel);
        }

        [Authorize]
        public IActionResult MyBuses()
        {
            return this.View();
        }
    }
}
