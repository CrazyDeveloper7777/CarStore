using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CarShop.Data.Common.Models;
using CarShop.Data.Models.Ads.Enums;
using CarShop.Data.Models.Vehicles;

namespace CarShop.Data.Models.Ads
{
    public class Ad : BaseDeletableModel<string>, IAd
    {
        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Dealer { get; set; }

        public string DealerId { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string PopulatedPlace { get; set; }
    }
}
