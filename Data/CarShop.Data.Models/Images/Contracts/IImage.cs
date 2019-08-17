using CarShop.Data.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Images
{
    public interface IImage
    {
        string Url { get; set; }

        Vehicle Vehicle { get; set; }

        string VehicleId { get; set; }
    }
}
