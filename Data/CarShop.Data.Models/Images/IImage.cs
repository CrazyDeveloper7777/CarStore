using CarShop.Data.Models.Ads;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Images
{
    public interface IImage
    {
        public string Name { get; set; }

        public long Length { get; set; }

        public string AdId { get; set; }

        public Ad Ad { get; set; }
    }
}
