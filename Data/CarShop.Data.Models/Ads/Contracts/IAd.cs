using CarShop.Data.Models.Ads.Enums;
using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public interface IAd
    {
        string PhoneNumber { get; set; }

        string VehicleType { get; set; }

        string Description { get; set; }

        ApplicationUser Dealer { get; set; }

        string DealerId { get; set; }

        string Region { get; set; }

        string PopulatedPlace { get; set; }
    }
}
