namespace CarShop.Data.Models.Vehicles
{
    using CarShop.Data.Common.Models;
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public abstract class Vehicle : BaseDeletableModel<string>, IVehicle
    {
        [Required]
        [Range(typeof(decimal), "0", "9999999")]
        public decimal Price { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string EngineType { get; set; }

        public int Power { get; set; }

        public string Color { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "9999999")]
        public int Run { get; set; }

        public VehicleState State { get; set; }

        public TransmissionType Transmission { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string PopulatedPlace { get; set; }

        [Required]
        public DateTime ManufacturedOn { get; set; }
    }
}
