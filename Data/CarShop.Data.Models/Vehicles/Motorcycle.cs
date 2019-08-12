using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models.Vehicles
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        [Required]
        public TypeOfCooling TypeOfCooling { get; set; }

        [Required]
        public int CubicMeter { get; set; }

        [Required]
        public int TactsOfEngine { get; set; }
    }
}
