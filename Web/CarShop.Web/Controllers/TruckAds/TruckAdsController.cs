using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.TruckAds
{
    public class TruckAdsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}