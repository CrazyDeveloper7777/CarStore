using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Web.ViewModels.BusAds
{
    public class EditBusAdViewModel : IMapFrom<BusAd>, IMapTo<BusAd>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"^0\d{9}$")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^0\d{9}$")]
        public string PhoneNumber2 { get; set; }

        [RegularExpression(@"^0\d{9}$")]
        public string PhoneNumber3 { get; set; }

        public string Description { get; set; }

        [Required]
        public string DealerId { get; set; }

        public string BusId { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string PopulatedPlace { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
