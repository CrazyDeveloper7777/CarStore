using CarShop.Data.Models.Vehicles;
using CarShop.Data.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Web.ViewModels.Cars
{
    public class MyCarsViewModel
    {
        public ICollection<Car> Cars { get; set; }
    }
}
