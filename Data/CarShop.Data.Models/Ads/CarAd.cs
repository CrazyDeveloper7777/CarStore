using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public class CarAd : Ad
    {
        public virtual Car Car { get; set; }

        [Required]
        public string CarId { get; set; }
    }
}
