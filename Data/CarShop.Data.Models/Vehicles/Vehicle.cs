namespace CarShop.Data.Models.Vehicles
{
    using CarShop.Data.Common.Models;
    
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicle : BaseDeletableModel<string>, IVehicle
    {
        public decimal Price { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string EngineType { get; set; }

        public int Power { get; set; }

        public string Color { get; set; }

        public int Run { get; set; }

        public VehicleState State { get; set; }

        public TransmissionType Transmission { get; set; }

        public string Region { get; set; }

        public string PopulatedPlace { get; set; }

        public DateTime ManufacturedOn { get; set; }
    }
}
