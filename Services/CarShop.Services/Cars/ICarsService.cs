using CarShop.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Cars
{
    public interface ICarsService
    {
        Task CreateAsync(CreateCarViewModel model);
    }
}
