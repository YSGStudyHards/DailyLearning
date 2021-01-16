using Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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

        [HttpPost]
        public IActionResult Index()
        {
            Queue q = new Queue();

            q.Enqueue("A");
            q.Enqueue("B");
            q.Enqueue("C");
            q.Enqueue("D");
            q.Enqueue("E");

            foreach (var item in q)
            {
                var data = item;
            }

            q.Enqueue("F");
            q.Enqueue("G");
            q.Enqueue("h");

            test02 t = new test02();

            var currentData =t.getName;

            string dataValue = "EFGHIJabcd";

            //string padLeftStr= dataValue.PadLeft(20, 'Z');//.Substring(0,1).ToUpper();
            //string padRightStr = dataValue.PadLeft(10,'U');

            string s = dataValue.Substring(3);
            string s2 = dataValue.Substring(0,10);

            string d = "小明同学";

            string str1 = d.Substring(2);
            string str = d.Substring(2, 1);
            //string str1 = null;
            //string str2 = "";
            //string str3 = String.Empty;

            return View();
        }
    }
}
