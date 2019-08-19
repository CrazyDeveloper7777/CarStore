﻿using AutoMapper;
using CarShop.Data.Models.Ads.Enums;
using CarShop.Data.Models.Vehicles;
using CarShop.Data.Models.Vehicles.Enums.Vehicle;
using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Web.ViewModels.Cars
{
    public class EditCarViewModel : IMapFrom<Car>, IMapTo<Car>
    {
        public string OwnerId { get; set; }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Price *")]
        [Range(0, 999999)]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Brand *")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Model *")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Engine Type *")]
        public EngineType EngineType { get; set; }

        [Required]
        [Display(Name = "Power *")]
        public int Power { get; set; }

        [Required]
        [Display(Name = "Color *")]
        public string Color { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "9999999")]
        [Display(Name = "Run *")]
        public int Run { get; set; }

        [Required]
        [Display(Name = "State *")]
        public VehicleState State { get; set; }

        [Required]
        [Display(Name = "Transmission *")]
        public TransmissionType Transmission { get; set; }

        [Required]
        [Display(Name = "Month *")]
        public int Month { get; set; }

        [Required]
        [Display(Name = "Year *")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Currency *")]
        public CurrencyType Currency { get; set; }

        [Required]
        [Display(Name = "Base Image Url")]
        public string BaseImageUrl { get; set; }

        public string Description { get; set; }
    }
}
