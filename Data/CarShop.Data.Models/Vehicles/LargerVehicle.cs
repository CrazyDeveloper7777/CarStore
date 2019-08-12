using CarShop.Data.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models.Vehicles
{
    public class LargerVehicle : Vehicle, ILargerVehicle
    {
        [Required]
        public int SeatsCount { get; set; }

        [Required]
        public int AxlesCount { get; set; }

        public int LoadInKg { get; set; }
    }
}
