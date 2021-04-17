using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeSiteWeb.Controllers
{
    public class FileUploadController : Controller
    {
        //接收前端图片文件信息
        [HttpPost]
        public JsonResult ImageUpload(FormContext context)
        {
            HttpPostedFileBase fileData = Request.Files[0];
            string appId = Request["appId"];
            string random = Request["random"];
            string sign = Request["sign"];
            string imgType = Request["imgType"];
            if (fileData != null)
            {
                try
                {
                    string fileName = Path.GetFileName(fileData.FileName);//原始文件名称
                    byte[] byteFileData = ReadFileBytes(fileData);//文件流转为字节流

                    var resultContext = HttpClientPostUpload(byteFileData, appId, random, sign, imgType, fileName);

                    return Json(new { code = 1, list = resultContext, msg = "上传成功~" });
                }
                catch (Exception ex)
                {
                    return Json(new { code = 0, msg = ex.Message });
                }
            }
            else
            {
                return Json(new { code = 0, msg = "图片上传失败，请稍后再试~" });
            }
        }

        //文件流转化为字节
        /// <summary>
        /// 文件流类型转化字节类型
        /// </summary>
        /// <param name="fileData">文件流数据</param>
        /// <returns></returns>
        private byte[] ReadFileBytes(HttpPostedFileBase fileData)
        {
            byte[] data;
            using (Stream inputStream = fileData.InputStream)
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
