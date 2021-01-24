using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Practice_Web.Models;

namespace Practice_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string classToolJson = "{\"Description\": \"枚举测试\",\"ClassToolDataList\": [{\"ClassTool\": 1}, {\"ClassTool\": 2}, {\"ClassTool\": 3}, {\"ClassTool\": 4},{\"ClassTool\": 5},{\"ClassTool\": 6}, {\"ClassTool\": 7},{\"ClassTool\": 8}, {\"ClassTool\": 9}, {\"ClassTool\":\"\"}]}";

            var dataList = JsonConvert.DeserializeObject<ClassToolModel>(classToolJson);

<<<<<<< HEAD
            string ImgCode = "ysg20180807/1c5bd382-ae4e-4160-b05b-a58f98509bbe.png";

            //是否存在2018
            if (ImgCode.IndexOf("2018", StringComparison.Ordinal) != -1)
            {
                int indexs= ImgCode.ToString().IndexOf("2018");

                ImgCode = "/uploads/FDImage/Cover/" +
                          ImgCode.ToString().Substring(ImgCode.ToString().IndexOf("2018"));
            }
=======
            var date = Convert.ToDateTime("00:11:37.770");
>>>>>>> 99671712a6e070163fa2ac01ab793bf2378c9e23


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
