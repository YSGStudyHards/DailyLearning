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
            return View();
        }

        public void DataJsonDeserializeObject()
        {
            #region 
            string classToolJson = "{\"Description\": \"枚举测试\",\"ClassToolDataList\": [{\"ClassTool\": 1}, {\"ClassTool\": 2}, {\"ClassTool\": 3}, {\"ClassTool\": 4},{\"ClassTool\": 5},{\"ClassTool\": 6}, {\"ClassTool\": 7},{\"ClassTool\": 8}, {\"ClassTool\": 9}, {\"ClassTool\":\"\"}]}";

            var deserializeObject = JsonConvert.DeserializeObject<ClassToolModel>(classToolJson);
            #endregion
        }

        /// <summary>
        /// 数据查询，移除
        /// </summary>
        public void ArrayFindRemove()
        {
            List<TestModel> testModelList = new List<TestModel>();
            testModelList.Add(new TestModel { Id = 1, Name = "大袁", Age = 33 });
            testModelList.Add(new TestModel { Id = 2, Name = "小明1", Age = 3 });
            testModelList.Add(new TestModel { Id = 3, Name = "小明2", Age = 4 });
            testModelList.Add(new TestModel { Id = 4, Name = "小明3", Age = 5 });
            testModelList.Add(new TestModel { Id = 5, Name = "小明4", Age = 5 });
            testModelList.Add(new TestModel { Id = 6, Name = "小明5", Age = 6 });
            testModelList.Add(new TestModel { Id = 1, Name = "小袁", Age = 33 });

            var findData = testModelList.FirstOrDefault(x => x.Name == "大袁");
            testModelList.Remove(findData);
        }

        public IActionResult Privacy()
        {
            var GetCompleteUrlStr = GetCompleteUrl();

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
