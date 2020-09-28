using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PracticeSiteWeb.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserServices userServices;

        public DefaultController(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}