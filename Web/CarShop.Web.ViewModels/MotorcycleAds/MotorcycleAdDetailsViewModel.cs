using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Data.Models.Vehicles;
using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Web.ViewModels.MotorcyclesAds
{
    public class MotorcycleAdDetailsViewModel : IMapTo<MotorcycleAd>, IMapFrom<MotorcycleAd>
    {
        public Motorcycle Motorcycle { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string PhoneNumber2 { get; set; }

        public string PhoneNumber3 { get; set; }

        public string Description { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string PopulatedPlace { get; set; }

        public Image Image1 { get; set; }

        public Image Image2 { get; set; }

        public Image Image3 { get; set; }

        public Image Image4 { get; set; }

        public Image Image5 { get; set; }

        public Image Image6 { get; set; }

        public Image Image7 { get; set; }

        public Image Image8 { get; set; }

        public Image Image9 { get; set; }
    }
}
