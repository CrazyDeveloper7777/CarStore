using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Data.Models.Vehicles;
using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Web.ViewModels.TruckAds
{
    public class TruckAdDetailsViewModel : IMapTo<TruckAd>, IMapFrom<TruckAd>
    {
        public Truck Truck { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string PhoneNumber2 { get; set; }

        public string PhoneNumber3 { get; set; }

        public string Description { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string PopulatedPlace { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
