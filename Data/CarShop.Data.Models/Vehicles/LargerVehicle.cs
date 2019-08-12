using CarShop.Data.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Vehicles
{
    public class LargerVehicle : Vehicle, ILargerVehicle
    {
        public int SeatsCount { get; set; }

        public int LoadInKg { get; set; }

        public int AxlesCount { get; set; }
    }
}
