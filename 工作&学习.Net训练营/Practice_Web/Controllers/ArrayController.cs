using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeSiteWeb.Controllers
{
    public class ArrayController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            //cc
            var multiTypeArray = new object[] {"小明",'H',2021,"hello world",'!' };

            foreach (var item in multiTypeArray)
            {
                var currentValue = item;
            }

            return View();
        }
    }
}
