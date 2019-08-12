using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CarShop.Data.Common.Models;
using CarShop.Data.Models.Vehicles;

namespace CarShop.Data.Models.Ads
{
    public class Ad : BaseDeletableModel<string>, IAd
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Validity { get; set; }

        [Required]
        public string Currency { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Dealer { get; set; }

        public string DealerId { get; set; }
    }
}
