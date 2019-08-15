using CarShop.Data.Models.Ads.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public class TopAd : Ad, ITopAd
    {
        public string PhoneNumber2 { get; set; }

        public string PhoneNumber3 { get; set; }
    }
}
