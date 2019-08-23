using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public class BusAd : Ad
    {
        public virtual Bus Bus { get; set; }

        [Required]
        public string BusId { get; set; }
    }
}
