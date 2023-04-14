using Microsoft.AspNetCore.Mvc;
using System;

namespace PracticeSiteWeb.Controllers
{
    /// <summary>
    /// 首先，定义一个 Attribute 类型，作为需要注入的元数据：
    /// </summary>
    public class MyAttribute : Attribute
    {
        public string TargetMethod { get; set; }

        public MyAttribute(string targetMethod)
        {
            TargetMethod = targetMethod;
        }
    }


    public class DependencyInjection : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 接着，我们定义一个需要被注入的依赖：
        /// </summary>
        [My("Foo")]
        public class FooService
        {
            public void Foo()
            {
                Console.WriteLine("Hello, Foo!");
            }
        }

        [My("Bar")]
        public class BarService
        {
            public void Bar()
            {
                Console.WriteLine("Hello, Bar!");
            }
        }



    }
}
