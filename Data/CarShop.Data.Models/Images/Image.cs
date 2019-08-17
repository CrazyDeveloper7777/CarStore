using CarShop.Data.Common.Models;
using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Images
{
    public class Image : BaseDeletableModel<string>, IImage
    {
        public string Url { get; set; }

        public Vehicle Vehicle { get; set; }

        public string VehicleId { get; set; }
    }
}
