using CarShop.Services.Motorcycles;
using CarShop.Web.ViewModels.Motorcycles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Web.Controllers.Motorcycles
{
    public class MotorcyclesController : BaseController
    {
        private readonly IMotorcyclesService motorcyclesService;

        public MotorcyclesController(IMotorcyclesService MotorcyclesService)
        {
            motorcyclesService = MotorcyclesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateMotorcycleViewModel inputModel)
        {
            await this.motorcyclesService.CreateAsync(inputModel);

            return this.RedirectToAction("MyMotorcycles");
        }

        [Authorize]
        [HttpGet("/Motorcycles/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var Motorcycle = await this.motorcyclesService.GetMotorcycleByIdAsync(id);
            var MotorcycleModel = AutoMapper.Mapper.Map<EditMotorcycleViewModel>(Motorcycle);
            MotorcycleModel.Year = Motorcycle.ManufacturedOn.Year;
            MotorcycleModel.Month = Motorcycle.ManufacturedOn.Month;

            return this.View(MotorcycleModel);
        }

        [Authorize]
        [HttpPost("/Motorcycles/Edit/{id}")]
        public async Task<IActionResult> Edit(EditMotorcycleViewModel MotorcycleModel)
        {
            MotorcycleModel.ManufacturedOn = new DateTime(MotorcycleModel.Year, MotorcycleModel.Month, 1);
            await this.motorcyclesService.EditAsync(MotorcycleModel);

            return this.RedirectToAction("MyMotorcycles");
        }

        [Authorize]
        [HttpGet("/Motorcycles/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Motorcycle = await this.motorcyclesService.GetMotorcycleByIdAsync(id);

            await this.motorcyclesService.DeleteAsync(Motorcycle);

            var message = "You have deleted your car successfully.";
            return this.Redirect($"/Motorcycles/MyMotorcycles?message={message}");
        }

        [Authorize]
        [HttpGet("/Motorcycles/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var Motorcycle = await this.motorcyclesService.GetMotorcycleByIdAsync(id);
            var MotorcycleModel = AutoMapper.Mapper.Map<DetailsMotorcycleViewModel>(Motorcycle);

            return this.View(MotorcycleModel);
        }

        [Authorize]
        public IActionResult MyMotorcycles()
        {
            return this.View();
        }
    }
}
