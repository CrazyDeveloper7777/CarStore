using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public class TruckAd : Ad
    {
        public virtual Truck Truck { get; set; }

        [Required]
        public string TruckId { get; set; }
    }
}
