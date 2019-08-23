using CarShop.Data.Models.Vehicles.Enums;
using CarShop.Data.Models.Vehicles;
using CarShop.Data.Models.Vehicles.Enums.Vehicle;
using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Web.ViewModels.Cars
{
    public class EditCarInputModel : IMapFrom<Car>, IMapTo<Car>
    {
        public string OwnerId { get; set; }

        public string Id { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public EngineType EngineType { get; set; }

        public int Power { get; set; }

        public string Color { get; set; }

        public int Run { get; set; }

        public VehicleState State { get; set; }

        public TransmissionType Transmission { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public CurrencyType Currency { get; set; }

        public string BaseImageUrl { get; set; }

        public string Description { get; set; }
    }
}
