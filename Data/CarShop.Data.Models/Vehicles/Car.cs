using CarShop.Data.Models.Vehicles.Contracts;
using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models.Vehicles
{
    public class Car : Vehicle, ICar
    {
        [Required]
        public int DoorsCount { get; set; }
    }
}
