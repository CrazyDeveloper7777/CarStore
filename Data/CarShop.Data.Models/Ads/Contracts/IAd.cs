using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public interface IAd
    {
        Vehicle Vehicle { get; set; }

        string VehicleId { get; set; }

        string PhoneNumber { get; set; }

        DateTime Validity { get; set; }

        string Currency { get; set; }

        string Description { get; set; }

        ApplicationUser Dealer { get; set; }

        string DealerId { get; set; }
    }
}
