﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AddressWebApp.Controllers
{
    [AllowAnonymous]
    public class GoogleApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}