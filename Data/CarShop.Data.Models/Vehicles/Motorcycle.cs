using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Vehicles
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        public TypeOfCooling TypeOfCooling { get; set; }

        public int CubicMeter { get; set; }

        public int TactsOfEngine { get; set; }
    }
}
