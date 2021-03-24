using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
            #region 
            string classToolJson = "{\"Description\": \"枚举测试\",\"ClassToolDataList\": [{\"ClassTool\": 1}, {\"ClassTool\": 2}, {\"ClassTool\": 3}, {\"ClassTool\": 4},{\"ClassTool\": 5},{\"ClassTool\": 6}, {\"ClassTool\": 7},{\"ClassTool\": 8}, {\"ClassTool\": 9}, {\"ClassTool\":\"\"}]}";

            var deserializeObject = JsonConvert.DeserializeObject<ClassToolModel>(classToolJson);
            #endregion

            //var getScheme = HttpContext.Request.Scheme;
            //var getRequestUrl = HttpContext.Request.Host;

            var getCompleteUrl= new StringBuilder()
                .Append(HttpContext.Request.Scheme)
                .Append("://")
                .Append(HttpContext.Request.Host)
                .Append(HttpContext.Request.PathBase)
                .Append(HttpContext.Request.Path)
                .Append(HttpContext.Request.QueryString)
                .ToString();

            return View();
        }

        public IActionResult Privacy()
        {
           var GetCompleteUrlStr=GetCompleteUrl();
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetHttpContentActionResult()
        {
            var getRequestUrl = HttpContext.Request.Host;

            return Json("");
        }


        /// <summary>
        /// 获取当前请求完整的Url地址
        /// </summary>
        /// <returns></returns>
        private string GetCompleteUrl()
        { 
           return new StringBuilder()
                .Append(HttpContext.Request.Scheme)
                .Append("://")
                .Append(HttpContext.Request.Host)
                .Append(HttpContext.Request.PathBase)
                .Append(HttpContext.Request.Path)
                .Append(HttpContext.Request.QueryString)
                .ToString();
        }
    }
}
