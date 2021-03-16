﻿using CarShop.Data.Models.Vehicles;
using CarShop.Data.Models.Vehicles.Enums;
using CarShop.Data.Models.Vehicles.Enums.Vehicle;
using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Web.ViewModels.Motorcycles
{
    public class DetailsMotorcycleViewModel : IMapTo<Motorcycle>, IMapFrom<Motorcycle>
    {
        [Required]
        [Range(0, 9999999)]
        public int Price { get; set; }

        [Required]
        public CurrencyType Currency { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public EngineType EngineType { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [Range(0, 9999999)]
        public int Run { get; set; }

        [Required]
        public VehicleState State { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        public TypeOfCooling TypeOfCooling { get; set; }

        [Required]
        public int CubicMeter { get; set; }

        [Required]
        public int TactsOfEngine { get; set; }
    }
}
