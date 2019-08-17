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

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel carModel)
        {
            carModel.OwnerId = await this.usersService.GetUserIdByUsernameAsync(this.User.Identity.Name);

            await this.carsService.CreateAsync(carModel);

            return this.Redirect("Vehicles/MyVehicles");
        }

        [HttpPost]
        public IActionResult Img(List<IFormFile> files)
        {
            ;

            return this.Redirect("/");
        }

        public IActionResult MyCars()
        {
            return this.View();
        }
    }
}
