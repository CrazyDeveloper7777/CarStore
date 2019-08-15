namespace CarShop.Data.Models.Vehicles
{
    using CarShop.Data.Common.Models;
    using CarShop.Data.Models.Ads.Enums;
    using CarShop.Data.Models.Vehicles.Enums.Vehicle;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public abstract class Vehicle : BaseDeletableModel<string>, IVehicle
    {
        public ApplicationUser Owner { get; set; }

        public string OwnerId { get; set; }

        public string Description { get; set; }

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

        public int Power { get; set; }

        public string Color { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "9999999")]
        public int Run { get; set; }

        public VehicleState State { get; set; }

        public TransmissionType Transmission { get; set; }

        [Required]
        public DateTime ManufacturedOn { get; set; }
    }
}
