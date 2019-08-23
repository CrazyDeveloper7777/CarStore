using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using CarShop.Data.Models.Vehicles.Contracts;

namespace CarShop.Data.Models.Vehicles
{
    public class Truck : Vehicle, ITruck
    {
        [Required]
        public int AxlesCount { get; set; }

        [Range(0, 999999)]
        public int LoadInKg { get; set; }
    }
}
