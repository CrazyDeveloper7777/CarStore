using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Vehicles.Contracts
{
    public interface ITruck
    {
        int AxlesCount { get; set; }

        int LoadInKg { get; set; }
    }
}
