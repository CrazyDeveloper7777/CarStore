using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers.BusAds
{
    public class BusAdsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}