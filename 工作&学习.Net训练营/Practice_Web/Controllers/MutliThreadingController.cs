﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeSiteWeb.Controllers
{
    public class MutliThreadingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
