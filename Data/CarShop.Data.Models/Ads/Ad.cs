using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CarShop.Data.Common.Models;
using CarShop.Data.Models.Images;
using CarShop.Data.Models.Vehicles;

namespace CarShop.Data.Models.Ads
{
    public abstract class Ad : BaseDeletableModel<string>, IAd
    {
        public Ad()
        {
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string PhoneNumber { get; set; }

        public string PhoneNumber2 { get; set; }

        public string PhoneNumber3 { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Dealer { get; set; }

        [Required]
        public string DealerId { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string PopulatedPlace { get; set; }

        public ICollection<Image> Images { get; set; }
       
    }
}
