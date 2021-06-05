using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeSiteWeb.Controllers
{
    public class ImageFileManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadImage()
        {
            var formFile = Request.Form;//获取请求发送过来的文件

            return Json(new {code=0,msg="successfully" });
        }

        //文件流转化为字节
        /// <summary>
        /// 文件流类型转化字节类型
        /// </summary>
        /// <param name="fileData">文件流数据</param>
        /// <returns></returns>
        //private byte[] ReadFileBytes(HttpPostedFileBase fileData)
        //{
        //    byte[] data;
        //    using (Stream inputStream = fileData.InputStream)
        //    {
        //        MemoryStream memoryStream = inputStream as MemoryStream;
        //        if (memoryStream == null)
        //        {
        //            memoryStream = new MemoryStream();
        //            inputStream.CopyTo(memoryStream);
        //        }
        //        data = memoryStream.ToArray();
        //    }
        //    return data;
        //}
    }
}
