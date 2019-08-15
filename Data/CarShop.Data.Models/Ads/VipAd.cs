using CarShop.Data.Models.Ads.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data.Models.Ads
{
    public class VipAd : Ad, IVipAd
    {
        public string PhoneNumber2 { get; set; }
    }
}
