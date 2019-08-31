using CarShop.Data.Models.Vehicles;
using CarShop.Services.Cars;
using CarShop.Services.Users;
using CarShop.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Web.Controllers
{
    public class CarsController : BaseController
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(ICarsService carsService, IUsersService usersService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel carModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(carModel);
            }

            carModel.OwnerId = await this.usersService.GetUserIdByUsernameAsync(this.User.Identity.Name);

            await this.carsService.CreateAsync(carModel);

            return this.RedirectToAction("MyCars");
        }

        [Authorize]
        [HttpGet("/Cars/Edit/{carId}")]
        public async Task<IActionResult> Edit(string carId)
        {
            var car = await this.carsService.GetCarByIdAsync(carId);
            var carModel = AutoMapper.Mapper.Map<EditCarViewModel>(car);
            carModel.Year = car.ManufacturedOn.Year;
            carModel.Month = car.ManufacturedOn.Month;

            return this.View(carModel);
        }

        [Authorize]
        [HttpPost("/Cars/Edit/{id}")]
        public async Task<IActionResult> Edit(EditCarViewModel carInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(carInputModel);
            }

            carInputModel.ManufacturedOn = new DateTime(carInputModel.Year, carInputModel.Month, 1);
            await this.carsService.EditAsync(carInputModel);

            return this.RedirectToAction("MyCars");
        }

        [Authorize]
        [HttpGet("/Cars/Delete/{carId}")]
        public async Task<IActionResult> Delete(string carId)
        {
            var car = await this.carsService.GetCarByIdAsync(carId);

            await this.carsService.DeleteAsync(car);

            var message = "You have deleted your car successfully.";
            return this.Redirect($"/Cars/MyCars?message={message}");
        }

        [Authorize]
        public async Task<IActionResult> MyCars()
        {
            var userId = await this.usersService.GetUserIdByUsernameAsync(this.User.Identity.Name);
            var cars = await this.carsService.GetAllCarsByUserIdAsync(userId);
            var viewModel = new MyCarsViewModel { Cars = cars };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet("/Cars/Details/{carId}")]
        public async Task<IActionResult> Details(string carId)
        {
            var car = await this.carsService.GetCarByIdAsync(carId);
            var carModel = AutoMapper.Mapper.Map<DetailsCarViewModel>(car);

            return this.View(carModel);
        }
    }
}
