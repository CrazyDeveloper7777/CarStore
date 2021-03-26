using CarShop.Data.Models.Images;
using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public interface IAd
    {
        string PhoneNumber { get; set; }

        string PhoneNumber2 { get; set; }

        string PhoneNumber3 { get; set; }

        string Description { get; set; }

        ApplicationUser Dealer { get; set; }

        string DealerId { get; set; }

        string Region { get; set; }

        string PopulatedPlace { get; set; }

        ICollection<Image> Images { get; set; }

    }
}
