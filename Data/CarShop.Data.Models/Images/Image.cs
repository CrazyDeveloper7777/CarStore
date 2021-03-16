using CarShop.Data.Common.Models;
using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Images
{
    public class Image : BaseDeletableModel<string>, IImage
    {

        public string Name { get; set; }

        public long Length { get; set; }

        public string AdId { get; set; }

        public Ad Ad { get; set; }
    }
}
