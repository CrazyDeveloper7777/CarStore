
using CarShop.Data.Models.Vehicles.Enums.Vehicle;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Vehicles
{
    public interface IVehicle
    {
        ApplicationUser Owner { get; set; }

        string OwnerId { get; set; }

        EngineType EngineType { get; set; }

        int Power { get; set; }

        int Price { get; set; }

        DateTime ManufacturedOn { get; set; }

        string Brand { get; set; }

        string Model { get; set; }

        string Color { get; set; }

        int Run { get; set; }

        VehicleState State { get; set; }

        TransmissionType Transmission { get; set; }
    }
}
