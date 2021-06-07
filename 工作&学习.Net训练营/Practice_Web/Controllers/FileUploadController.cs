using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        // 由参数中传入
        public JsonResult UploadVersion(IFormFile file)
        {
            var formFile = Request.Form.Files[0];//获取请求发送过来的文件
            // 这边直接使用formData
            return Json(new {code=0,msg="ok" });
        }


        /// <summary>
        /// 单文件上传（Ajax，Form表单都适用）模拟第三方服务端接口
        /// </summary>
        /// <param name="file">表单文件信息</param>
        /// <returns></returns>
        public JsonResult SingleFileUpload(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var currentDate = DateTime.Now;
                    var webRootPath = _hostingEnvironment.WebRootPath;//>>>相当于HttpContext.Current.Server.MapPath("") 

                    var filePath = $"/UploadFile/{currentDate:yyyyMMdd}/";

                    //创建每日存储文件夹
                    if (!Directory.Exists(webRootPath + filePath))
                    {
                        Directory.CreateDirectory(webRootPath + filePath);
                    }

                    //文件后缀
                    var fileExtension = Path.GetExtension(file.FileName);//获取文件格式，拓展名

                    //判断文件大小
                    var fileSize = file.Length;

                    if (fileSize > 1024 * 1024 * 10) //10M TODO:(1mb=1024X1024b)
                    {
                        return Json(new { isSuccess = false, resultMsg = "上传的文件不能大于10M" });
                    }

                    //保存的文件名称(以名称和保存时间命名)
                    var saveName = file.FileName.Substring(0, file.FileName.LastIndexOf('.')) + "_" + currentDate.ToString("HHmmss") + fileExtension;

                    //文件保存
                    using (var fs = System.IO.File.Create(webRootPath + filePath + saveName))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }

                    //完整的文件路径
                    var completeFilePath = Path.Combine(filePath, saveName);

                    return Json(new { isSuccess = true, returnMsg = "上传成功", completeFilePath = completeFilePath });
                }
                else
                {
                    return Json(new { isSuccess = false, resultMsg = "上传失败，未检测上传的文件信息~" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, resultMsg = "文件保存失败，异常信息为：" + ex.Message });
            }
        }


    }
}
