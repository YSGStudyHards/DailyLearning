using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeSiteWeb.Controllers
{
    /// <summary>
    /// C# 数组（Array）
    /// </summary>
    public class ArrayController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            //多类型数组定义
            var multiTypeArray = new object[] {"小明",'H',2021,"hello world",'!' };

            var getData = new List<object>();

            foreach (var item in multiTypeArray)
            {
                getData.Add(item);
            }

            return Json(new {data= getData,code=0 });
        }
    }
}
