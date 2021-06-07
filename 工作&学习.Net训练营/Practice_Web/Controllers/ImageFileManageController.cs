using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PracticeSiteWeb.Controllers
{
    /// <summary>
    /// 图片文件管理
    /// </summary>
    public class ImageFileManageController : Controller
    {
        /// <summary>
        /// 接收Ajax传递的文件流
        /// </summary>
        /// <param name="files">表单文件信息</param>
        /// <returns></returns>
        public IActionResult UploadImage(IFormFile files)
        {
            //var files = Request.Form.Files[0];//获取请求发送过来的文件
            if (files.Length <= 0)
                return Json(new { code = 1, msg = "请选择需要上传的文件~" });

            var fileBytes = ReadFileBytes(files);
            var fileExtension = Path.GetExtension(files.FileName);//获取文件格式，拓展名
            var result = HttpClientHelper._.HttpClientPost("https://localhost:44347/FileUpload/SingleFileUpload", fileBytes, fileExtension, files.FileName);

            var resultObj = JsonConvert.DeserializeObject<UploadReponse>(result);
            if (resultObj.IsSuccess)
            {
                return Json(new { code = 0, msg = resultObj });
            }
            else
            {
                return Json(new { code = 1, msg = resultObj.ReturnMsg });
            }
        }


        /// <summary>
        /// 文件流类型转化字节类型
        /// </summary>
        /// <param name="fileData">表单文件信息</param>
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


    /// <summary>
    /// 上传响应模型
    /// </summary>
    public class UploadReponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 完整地址
        /// </summary>
        public string CompleteFilePath { get; set; }
    }

}
