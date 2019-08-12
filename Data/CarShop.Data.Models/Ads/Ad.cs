using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CarShop.Data.Common.Models;
using CarShop.Data.Models.Vehicles;

namespace CarShop.Data.Models.Ads
{
    public class Ad : BaseDeletableModel<string>, IAd
    {
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Vehicle")]
        public string VehicleId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Validity { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Dealer { get; set; }

        [ForeignKey("Dealer")]
        public string DealerId { get; set; }
    }
}
