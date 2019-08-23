using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public class MotorcycleAd : Ad
    {
        public virtual Motorcycle Motorcycle { get; set; }

        [Required]
        public string MotorcycleId { get; set; }
    }
}
