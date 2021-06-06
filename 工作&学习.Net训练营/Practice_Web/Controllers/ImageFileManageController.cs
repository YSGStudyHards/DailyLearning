using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// 接收ajax传递的文件流
        /// </summary>
        /// <returns></returns>
        public IActionResult UploadImage()
        {
            var formFile = Request.Form.Files[0];//获取请求发送过来的文件

            if (formFile.Length <= 0)
                return Json(new { code = 1, msg = "请选择需要上传的文件~" });

            var fileBytes = ReadFileBytes(formFile);
            var fileExtension = Path.GetExtension(formFile.FileName);//获取文件格式，拓展名
            var result = HttpClientHelper._.HttpClientPost("https://localhost:44347/FileUpload/UploadVersion", fileBytes, fileExtension, formFile.FileName);

            return Json(new { code = 0, msg = "successfully" });
        }


        /// <summary>
        /// 文件流类型转化字节类型
        /// </summary>
        /// <param name="fileData">文件流数据</param>
        /// <returns></returns>
        private byte[] ReadFileBytes(IFormFile fileData)
        {
            byte[] data;
            using (Stream inputStream = fileData.OpenReadStream())//读取上传文件的请求流
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            return data;
        }
    }
}
