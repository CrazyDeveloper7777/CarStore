using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Web.Controllers.Ads
{
    public class AdsController : BaseController
    {
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult Search()
        {
            return this.View();
        }

    }
}
