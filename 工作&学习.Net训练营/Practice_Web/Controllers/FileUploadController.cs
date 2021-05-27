using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeSiteWeb.Controllers
{
    public class FileUploadController : Controller
    {
        private static IHostingEnvironment _hostingEnvironment;

        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 单文件上传（ajax，Form表单都适用）
        /// </summary>
        /// <returns></returns>
        public JsonResult SingleFileUpload()
        {
            var formFile = Request.Form.Files[0];//获取请求发送过来的文件
            var currentDate = DateTime.Now;
            var webRootPath = _hostingEnvironment.WebRootPath;//>>>相当于HttpContext.Current.Server.MapPath("") 

            try
            {
                var filePath = $"/UploadFile/{currentDate:yyyyMMdd}/";

                //创建每日存储文件夹
                if (!Directory.Exists(webRootPath + filePath))
                {
                    Directory.CreateDirectory(webRootPath + filePath);
                }

                if (formFile != null)
                {
                    //文件后缀
                    var fileExtension = Path.GetExtension(formFile.FileName);//获取文件格式，拓展名

                    //判断文件大小
                    var fileSize = formFile.Length;

                    if (fileSize > 1024 * 1024 * 10) //10M TODO:(1mb=1024X1024b)
                    {
                        return new JsonResult(new { isSuccess = false, resultMsg = "上传的文件不能大于10M" });
                    }

                    //保存的文件名称(以名称和保存时间命名)
                    var saveName = formFile.FileName.Substring(0, formFile.FileName.LastIndexOf('.')) + "_" + currentDate.ToString("HHmmss") + fileExtension;

                    //文件保存
                    using (var fs = System.IO.File.Create(webRootPath + filePath + saveName))
                    {
                        formFile.CopyTo(fs);
                        fs.Flush();
                    }

                    //完整的文件路径
                    var completeFilePath = Path.Combine(filePath, saveName);

                    return new JsonResult(new { isSuccess = true, returnMsg = "上传成功", completeFilePath = completeFilePath });
                }
                else
                {
                    return new JsonResult(new { isSuccess = false, resultMsg = "上传失败，未检测上传的文件信息~" });
                }

            }
            catch (Exception ex)
            {
                return new JsonResult(new { isSuccess = false, resultMsg = "文件保存失败，异常信息为：" + ex.Message });
            }
        }

        ////文件流转化为字节
        ///// <summary>
        ///// 文件流类型转化字节类型
        ///// </summary>
        ///// <param name="fileData">文件流数据</param>
        ///// <returns></returns>
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
