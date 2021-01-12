using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// C#队列相关操作
/// </summary>
namespace PracticeSiteWeb.Controllers
{
    public class QueueController : Controller
    {
        public IActionResult Index()
        {
            Queue queue = new System.Collections.Generic.Queue();

            return View();
        }
    }
}
