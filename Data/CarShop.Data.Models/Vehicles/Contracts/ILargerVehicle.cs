using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Vehicles.Contracts
{
    public interface ILargerVehicle
    {
        int SeatsCount { get; set; }

        int LoadInKg { get; set; }

        int AxlesCount { get; set; }
    }
}
